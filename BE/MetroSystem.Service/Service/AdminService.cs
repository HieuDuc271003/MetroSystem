using FirebaseAdmin.Auth;
using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using MetroSystem.Data.RequestModel.ResponseUserModel;
using MetroSystem.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroSystem.Service.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepositories _adminRepositories;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ItokenService _tokenService;

        public AdminService(IAdminRepositories adminRepositories, IConfiguration configuration, IUnitOfWork unitOfWork, ItokenService tokenService)
        {
            _adminRepositories = adminRepositories;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<bool> SetUserStatusAsync(string email, bool status)
        {
            var user = await _unitOfWork.Admin.GetEmailIdAsync(email);
            if (user == null)
            {
                return false;
            }

            await _unitOfWork.Admin.UpdateStatusAsync(email, status);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<List<ResponseUserModel>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.Admin.GetAllUsersAsync();
            return users.Select(u => new ResponseUserModel
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Status = u.Status,
                RoleId = u.RoleId,
                FirebaseUid = u.FirebaseUid,
                RefreshToken = u.RefreshToken,
                RefreshTokenExpiry = u.RefreshTokenExpiry
            }).ToList();
        }

        public async Task<ResponseUserModel> CreateStaffAsync(RequestCreateStaff request)
        {
            // Kiểm tra xem email đã tồn tại chưa
            var existingUser = await _unitOfWork.Admin.GetEmailIdAsync(request.Email);
            if (existingUser != null)
            {
                throw new Exception("Email đã tồn tại!");
            }

            // ✅ Tạo user trên Firebase
            UserRecordArgs args = new UserRecordArgs
            {
                Email = request.Email,
                EmailVerified = true,
                Password = request.Password,
                DisplayName = request.Name,
                Disabled = false
            };

            UserRecord userRecord;
            try
            {
                userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(args);
            }
            catch (FirebaseAuthException ex)
            {
                throw new Exception($"Lỗi Firebase: {ex.Message}");
            }

            // ✅ Tạo user trong database
            var newUser = new User
            {
                UserId = Guid.NewGuid().ToString(),
                FirebaseUid = userRecord.Uid,
                Email = request.Email,
                Name = request.Name,
                RoleId = "R3", // Role Staff
                Status = true,
                Password = request.Password,
                RefreshToken = null,
                RefreshTokenExpiry = DateTime.UtcNow.AddDays(7)
            };

            try
            {
                await _unitOfWork.Admin.AddUserAsync(newUser);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Lỗi khi lưu dữ liệu vào database: {ex.InnerException?.Message ?? ex.Message}");
            }
            // ✅ Chuyển đổi `User` thành `ResponseUserModel`
            var responseUser = new ResponseUserModel
            {
                UserId = newUser.UserId,
                FirebaseUid = newUser.FirebaseUid,
                Email = newUser.Email,
                Name = newUser.Name,
                RoleId = newUser.RoleId,
                Status = newUser.Status,
                Password = newUser.Password,
            };

            return responseUser;
        }

    }
}
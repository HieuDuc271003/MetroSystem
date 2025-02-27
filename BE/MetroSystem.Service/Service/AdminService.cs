using MetroSystem.Data.Interface;
using MetroSystem.Service.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepositories _adminRepositories;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IAdminRepositories adminRepositories, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _adminRepositories = adminRepositories;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> SetUserStatusAsync(string email, bool status)
        {
            var user = await _unitOfWork.Admin.GetEmailIdAsync(email);
            if (user == null)
            {
                return false; // User không tồn tại
            }

            await _unitOfWork.Admin.UpdateStatusAsync(email, status);
            await _unitOfWork.SaveChangesAsync(); // Lưu thay đổi vào DB

            return true;
        }
    }
}

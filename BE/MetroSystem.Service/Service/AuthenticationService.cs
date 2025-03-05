using FirebaseAdmin.Auth;
using MetroSystem.Data.Enities;
using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using MetroSystem.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepositories _authenticationRepository;
        private readonly IConfiguration _configuration;
        private readonly MetroSystemContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ItokenService _tokenService;

        public AuthenticationService(IAuthenticationRepositories authenticationRepository, IConfiguration configuration, MetroSystemContext context, IUnitOfWork unitOfWork, ItokenService tokenservice
            )
        {
            _authenticationRepository = authenticationRepository;
            _configuration = configuration;
            _context = context;
            _unitOfWork = unitOfWork;
            _tokenService = tokenservice;
        }

        public async Task<(User, string, string)> AuthenticateWithGoogleAsync(string firebaseUid, string email, string name)
        {
            var user = await _unitOfWork.Authentication.GetByFirebaseUidAsync(firebaseUid)
                   ?? await _unitOfWork.Authentication.GetByEmailAsync(email);

            if (user == null)
            {
                user = new User
                {
                    FirebaseUid = firebaseUid,
                    UserId = Guid.NewGuid().ToString(),
                    Name = name,
                    Email = email,
                    RoleId = "R2",
                    Password = "", // Không cần mật khẩu khi dùng Google login
                    RefreshToken = "", // Tránh NULL gây lỗi
                    RefreshTokenExpiry = DateTime.UtcNow.AddDays(7) // Đặt giá trị mặc định
                };

                await _unitOfWork.Authentication.AddAsync(user);
                await _unitOfWork.SaveChangesAsync();
            }
            else if (string.IsNullOrEmpty(user.FirebaseUid))
            {
                user.FirebaseUid = firebaseUid;
                await _unitOfWork.SaveChangesAsync();
            }

            var jwtToken = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return (user, jwtToken, refreshToken);
        }
    }
}

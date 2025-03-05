using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using MetroSystem.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Service
{
    public class TokenService : ItokenService
    {
        private readonly IConfiguration _configuration;
        private readonly MetroSystemContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public TokenService( IConfiguration configuration, MetroSystemContext context, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            var secretKey = jwtSettings["Key"];
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new ArgumentNullException("Jwt Secret Key is missing in appsettings.json");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.NameIdentifier, user.UserId),
        new Claim(ClaimTypes.Role, user.RoleId)
    };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken() => Guid.NewGuid().ToString("N");

        public async Task<(string JwtToken, string RefreshToken)> GenerateTokens(User user)
        {
            var jwtToken = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7); // Refresh token hết hạn sau 7 ngày

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return (jwtToken, refreshToken);
        }

        public async Task<string> RefreshTokenAsync(string refreshToken)
        {
            // Tìm user có RefreshToken tương ứng
            var user = _context.Users.FirstOrDefault(u => u.RefreshToken == refreshToken);
            if (user == null || user.RefreshTokenExpiry < DateTime.UtcNow)
            {
                return null; // Token không hợp lệ hoặc đã hết hạn
            }

            // Tạo token mới
            var newToken = GenerateJwtToken(user);

            // Cập nhật refresh token mới (tuỳ chọn)
            user.RefreshToken = GenerateRefreshToken();
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return newToken;
        }


    }
}

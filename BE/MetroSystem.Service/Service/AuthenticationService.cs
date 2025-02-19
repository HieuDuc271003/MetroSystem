using MetroSystem.Data.Enities;
using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using MetroSystem.Service.Interface;
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
        private readonly AppDbContext _context;

        public AuthenticationService(IAuthenticationRepositories authenticationRepository, IConfiguration configuration, AppDbContext context)
        {
            _authenticationRepository = authenticationRepository;
            _configuration = configuration;
            _context = context;
        }
        public async Task<string> AuthenticationLogin(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                return null; // Trả về null nếu không tìm thấy user
            }

            // Tạo JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<string> Register(RegisterUserDto registerDto)
        {
            // Kiểm tra email đã tồn tại chưa
            var existingUser = await _authenticationRepository.GetUserByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                return "Email already exists!";
            }

            var user = new User
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password), // Mã hóa mật khẩu
                PhoneNumber = registerDto.PhoneNumber,
                RoleId = 2, // Mặc định là User (RoleId = 2)
                Status = true
            };

            // Lưu vào database
            await _authenticationRepository.Register(user);

            return "User registered successfully!";
        }
    }
}

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

        public AuthenticationService(IAuthenticationRepositories authenticationRepository, IConfiguration configuration, MetroSystemContext context, IUnitOfWork unitOfWork)
        {
            _authenticationRepository = authenticationRepository;
            _configuration = configuration;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> AuthenticateWithGoogleAsync(string firebaseUid, string email, string name)
        {
            //var user = await _context.Users.FirstOrDefaultAsync(u => u.FirebaseUid == firebaseUid || u.Email == email);

            //if (user == null)
            //{
            //    user = new User
            //    {
            //        FirebaseUid = firebaseUid,
            //        UserId = Guid.NewGuid().ToString(),
            //        Name = name,
            //        Email = email,
            //        RoleId = "R2",
            //        Password = "",
            //    };

            //    _context.Users.Add(user);
            //    await _context.SaveChangesAsync();
            //}
            //else
            //{
            //    if (string.IsNullOrEmpty(user.FirebaseUid))
            //    {
            //        user.FirebaseUid = firebaseUid;
            //        await _context.SaveChangesAsync();
            //    }
            //}

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
                    Password = "",
                };

                await _unitOfWork.Authentication.AddAsync(user);
                await _unitOfWork.SaveChangesAsync();
            }
            else if (string.IsNullOrEmpty(user.FirebaseUid))
            {
                user.FirebaseUid = firebaseUid;
                await _unitOfWork.SaveChangesAsync();
            }

            return user;
        }
        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.UserId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

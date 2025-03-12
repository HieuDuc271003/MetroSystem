using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Repositories
{
    public class AuthenticationRepositorises : IAuthenticationRepositories
    {
        private readonly MetroSystemContext _context;

        public AuthenticationRepositorises(MetroSystemContext context)
        {
            _context = context;
        }


        public async Task<User> GetByFirebaseUidAsync(string firebaseUid)
        {
            return await _context.Users
                                 .FirstOrDefaultAsync(u => u.FirebaseUid == firebaseUid);
        }

        // Tìm người dùng theo email
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
                                 .FirstOrDefaultAsync(u => u.Email == email);
        }

        // Thêm người dùng vào cơ sở dữ liệu
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByUserIdAsync(string userId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }
}

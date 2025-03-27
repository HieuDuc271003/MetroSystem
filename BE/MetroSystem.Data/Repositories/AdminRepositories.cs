

using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroSystem.Data.Repositories
{
    public class AdminRepositories : IAdminRepositories
    {
        private readonly MetroSystemContext _context;

        public AdminRepositories(MetroSystemContext context)
        {
            _context = context;
        }

        public async Task UpdateStatusAsync(string email, bool status)
        {
            var user = await GetEmailIdAsync(email);
            if (user != null)
            {
                user.Status = status;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> GetEmailIdAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
       
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

    }
}


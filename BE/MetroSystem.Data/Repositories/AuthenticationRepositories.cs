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
        private readonly AppDbContext _context;

        public AuthenticationRepositorises(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task Register(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}

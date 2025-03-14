﻿using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                user.Status = status ? true : false; // Khi True thì status = 1, khi False thì status = 2
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> GetEmailIdAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}

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
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly MetroSystemContext _context;

        public FeedbackRepository(MetroSystemContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }
        public async Task<Feedback> GetByIdAsync(string feedbackId)
        {
            if (!Guid.TryParse(feedbackId, out var guid))
            {
                return null;
            }
            return await _context.Feedbacks.FirstOrDefaultAsync(f => f.FeedbackId == guid.ToString());
        }

        public async Task<IEnumerable<Feedback>> GetByUserIdAsync(string userId)
        {
            return await _context.Feedbacks.Where(f => f.UserId == userId).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Feedback feedback)
        {
            _context.Feedbacks.Update(feedback);
            return await _context.SaveChangesAsync() > 0;
        }
    }

}

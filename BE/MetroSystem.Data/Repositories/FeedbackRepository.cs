using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
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
    }

}

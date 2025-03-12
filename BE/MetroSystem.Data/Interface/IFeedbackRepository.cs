using MetroSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Interface
{
    public interface IFeedbackRepository
    {
        Task AddAsync(Feedback feedback);
        Task<bool> SaveChangesAsync();
        Task<bool> UpdateAsync(Feedback feedback);
        Task<IEnumerable<Feedback>> GetByUserIdAsync(string userId);
        Task<IEnumerable<Feedback>> GetAllAsync();

        Task<Feedback> GetByIdAsync(string feedbackId);

    }

}

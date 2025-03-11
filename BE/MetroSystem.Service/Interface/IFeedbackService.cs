using MetroSystem.Data.Enities.FeedBackMod;
using MetroSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Interface
{
    public interface IFeedbackService
    {
        Task<Feedback> CreateFeedbackAsync(FeedbackDto feedbackDto, string userId);
        Task<IEnumerable<Feedback>> GetAllFeedbacksAsync();
        Task<IEnumerable<Feedback>> GetFeedbacksByUserIdAsync(string userId);

        Task<Feedback> UpdateFeedbackAsync(string feedbackId, FeedbackDTOUpdate feedbackDto);


    }
}

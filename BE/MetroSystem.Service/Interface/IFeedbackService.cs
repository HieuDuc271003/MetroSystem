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
    }
}

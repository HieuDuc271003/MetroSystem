using MetroSystem.Data.Enities.FeedBackMod;
using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using MetroSystem.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<Feedback> CreateFeedbackAsync(FeedbackDto feedbackDto, string userId)
        {
            var newFeedback = new Feedback
            {
                FeedbackId = Guid.NewGuid().ToString(),
                UserId = userId,
                LineId = feedbackDto.LineId,
                Comment = feedbackDto.Comment,
                Rating = feedbackDto.Rating
            };

            await _feedbackRepository.AddAsync(newFeedback);
            var success = await _feedbackRepository.SaveChangesAsync();

            return success ? newFeedback : null;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync()
        {
            return await _feedbackRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Feedback>> GetFeedbacksByUserIdAsync(string userId)
        {
            return await _feedbackRepository.GetByUserIdAsync(userId);
        }

        public async Task<Feedback> UpdateFeedbackAsync(string feedbackId, FeedbackDTOUpdate feedbackDto)
        {
            var existingFeedback = await _feedbackRepository.GetByIdAsync(feedbackId);
            if (existingFeedback == null)
            {
                throw new Exception($"Feedback with ID {feedbackId} not found.");
            }

            existingFeedback.Comment = feedbackDto.Comment;
            existingFeedback.Rating = feedbackDto.Rating;

            var success = await _feedbackRepository.SaveChangesAsync();
            return success ? existingFeedback : null;
        }
    }

}

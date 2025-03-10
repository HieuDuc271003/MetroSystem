using MetroSystem.Data.Enities.FeedBackMod;
using MetroSystem.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MetroSystem.Controllers
{
    [ApiController]
    [Route("api/feedback")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost("create")]
        [Authorize] // Cần xác thực
        public async Task<IActionResult> CreateFeedback([FromBody] FeedbackDto feedbackDto)
        {
            if (feedbackDto == null)
            {
                return BadRequest(new { message = "Invalid feedback data." });
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User is not authenticated." });
            }

            var feedback = await _feedbackService.CreateFeedbackAsync(feedbackDto, userId);
            if (feedback == null)
            {
                return BadRequest(new { message = "Failed to create feedback." });
            }

            return Ok(new
            {
                feedback.FeedbackId,
                feedback.UserId,
                feedback.LineId,
                feedback.Comment,
                feedback.Rating
            });
        }
    }

}

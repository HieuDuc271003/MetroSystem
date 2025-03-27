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

        //[HttpPost("create")]
        [HttpPost]
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

        //[HttpGet("all")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            var feedbacks = await _feedbackService.GetAllFeedbacksAsync();
            return Ok(feedbacks);
        }

        [HttpGet("user")]
        [Authorize]
        public async Task<IActionResult> GetFeedbacksByUserId()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "User is not authenticated." });

            var feedbacks = await _feedbackService.GetFeedbacksByUserIdAsync(userId);
            return Ok(feedbacks);
        }

        //[HttpPut("update/{feedbackId}")]
        [HttpPut("{feedbackId}")]
        [Authorize]
        public async Task<IActionResult> UpdateFeedback(string feedbackId, [FromBody] FeedbackDTOUpdate feedbackDto)
        {
            if (feedbackDto == null)
            {
                return BadRequest(new { message = "Invalid feedback data." });
            }

            var success = await _feedbackService.UpdateFeedbackAsync(feedbackId, feedbackDto);
            if (success == null)
            {
                return NotFound(new { message = "Feedback not found or failed to update." });
            }

            return Ok(new { message = "Feedback updated successfully." });
        }

    }

}

using MetroSystem.Data.Enities.BookMarkMod;
using MetroSystem.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MetroSystem.Controllers
{
    [ApiController]
    [Route("api/bookmark")]
    public class BookmarkController : ControllerBase
    {
        private readonly IBookmarkService _bookmarkService;

        public BookmarkController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }

<<<<<<< HEAD
        //[HttpPost("add")]
        [HttpPost]
=======
        [HttpPost("add")]
>>>>>>> e644d97 (Adjust the Admin Pages)
        [Authorize]
        public async Task<IActionResult> AddBookmark([FromBody] BookmarkDto bookmarkDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User is not authenticated." });
            }

            try
            {
                var success = await _bookmarkService.AddBookmarkAsync(userId, bookmarkDto.StationId, bookmarkDto.LineId);
                if (!success)
                {
                    return BadRequest(new { message = "Failed to add bookmark." });
                }

                return Ok(new { message = "Bookmark added successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

<<<<<<< HEAD
        //[HttpGet("get")]
        [HttpGet("bookmarks")]
=======
        [HttpGet("get")]
>>>>>>> e644d97 (Adjust the Admin Pages)
        [Authorize]
        public async Task<IActionResult> GetBookmarks()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User is not authenticated." });
            }

            var bookmarks = await _bookmarkService.GetBookmarksByUserIdAsync(userId);
            return Ok(bookmarks);
        }


<<<<<<< HEAD
        //[HttpDelete("delete/{stationId}")]
        [HttpDelete("{stationId}")]
=======
        [HttpDelete("delete/{stationId}")]
>>>>>>> e644d97 (Adjust the Admin Pages)
        [Authorize]
        public async Task<IActionResult> DeleteBookmark(string stationId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User is not authenticated." });
            }

            try
            {
                var success = await _bookmarkService.DeleteBookmarkAsync(userId, stationId);
                if (!success)
                {
                    return BadRequest(new { message = "Failed to delete bookmark." });
                }

                return Ok(new { message = "Bookmark deleted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

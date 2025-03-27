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

        //[HttpPost("add")]
        [HttpPost]
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

        //[HttpGet("get")]
        [HttpGet("bookmarks")]
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


        //[HttpDelete("delete/{stationId}")]
        [HttpDelete("{stationId}")]
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

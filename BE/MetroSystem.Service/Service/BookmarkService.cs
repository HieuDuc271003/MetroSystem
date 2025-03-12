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
    public class BookmarkService : IBookmarkService
    {
        private readonly IBookmarkRepository _bookmarkRepository;

        public BookmarkService(IBookmarkRepository bookmarkRepository)
        {
            _bookmarkRepository = bookmarkRepository;
        }

        public async Task<bool> AddBookmarkAsync(string userId, string stationId, string lineId)
        {
            // Kiểm tra xem Bookmark đã tồn tại chưa
            var existingBookmark = await _bookmarkRepository.GetByUserAndStationAsync(userId, stationId);
            if (existingBookmark != null)
            {
                throw new Exception("Bookmark already exists for this station.");
            }

            var newBookmark = new Bookmark
            {
                BookmarkId = Guid.NewGuid().ToString(),
                UserId = userId,
                StationId = stationId,
                LineId = lineId,
                Status = true
            };

            await _bookmarkRepository.AddAsync(newBookmark);
            return await _bookmarkRepository.SaveChangesAsync();
        }

        public async Task<List<Bookmark>> GetBookmarksByUserIdAsync(string userId)
        {
            return await _bookmarkRepository.GetByUserIdAsync(userId);
        }

        public async Task<bool> DeleteBookmarkAsync(string userId, string stationId)
        {
            var bookmark = await _bookmarkRepository.GetByUserAndStationAsync(userId, stationId);
            if(bookmark == null)
            {
                throw new Exception("can't found");
            }
            await _bookmarkRepository.DeleteAsync(bookmark);
            return await _bookmarkRepository.SaveChangesAsync();
        }
    }
}

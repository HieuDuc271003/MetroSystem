using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Repositories
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly MetroSystemContext _context;

        public BookmarkRepository(MetroSystemContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Bookmark bookmark)
        {
            await _context.Bookmarks.AddAsync(bookmark);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Bookmark> GetByUserAndStationAsync(string userId, string stationId)
        {
            return await _context.Bookmarks
                .FirstOrDefaultAsync(b => b.UserId == userId && b.StationId == stationId);
        }

        public async Task<List<Bookmark>> GetByUserIdAsync(string userId)
        {
            return await _context.Bookmarks
                .Where(b => b.UserId == userId)
                .Include(b => b.Station)
                .Include(b => b.Line)
                .ToListAsync();
        }

        public async Task DeleteAsync(Bookmark bookmark)
        {
            await _context.Bookmarks.AddAsync(bookmark);
        }
    }
}

using MetroSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Interface
{
    public interface IBookmarkRepository
    {
        Task AddAsync(Bookmark bookmark);
        Task<bool> SaveChangesAsync();
        Task<Bookmark> GetByUserAndStationAsync(string userId, string stationId);
        Task<List<Bookmark>> GetByUserIdAsync(string userId);

        Task DeleteAsync(Bookmark bookmark);
    }
}

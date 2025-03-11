using MetroSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Interface
{
    public interface IBookmarkService
    {
        Task<bool> AddBookmarkAsync(string userId, string stationId, string lineId);
        Task<List<Bookmark>> GetBookmarksByUserIdAsync(string userId);
    }
}

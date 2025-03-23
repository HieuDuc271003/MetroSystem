using MetroSystem.Data.Models;
using MetroSystem.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Repositories
{
    public class MetroStationRepository : IMetroStationRepository
    {

        private readonly MetroSystemContext _context;

        public MetroStationRepository(MetroSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MetroStation>> GetAllAsync()
        {
            return await _context.MetroStations.ToListAsync();
        }

        public async Task<MetroStation> GetByStationNameAsync(string stationName) // 🔹 Đổi từ GetByIdAsync thành GetByStationNameAsync
        {
            return await _context.MetroStations
                .FirstOrDefaultAsync(station => station.StationName == stationName);
        }

        public async Task AddAsync(MetroStation station)
        {
            await _context.MetroStations.AddAsync(station);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<MetroStation> GetByIdAsync(string stationId) // ✅ Thêm phương thức tìm trạm theo ID
        {
            return await _context.MetroStations.FindAsync(stationId);
        }
        public async Task<bool> DeleteMetroStationByIdAsync(string StationId)
        {
            var metroStation = await _context.MetroStations.FindAsync(StationId);
            if (metroStation == null) return false;

            _context.MetroStations.Remove(metroStation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

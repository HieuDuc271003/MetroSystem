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
    public class BusStationRepository : IBusStationRepository
    {
        private readonly MetroSystemContext _context;
        public BusStationRepository(MetroSystemContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBusStationAsync(BusStation busStation)
        {
            await _context.BusStations.AddAsync(busStation);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<BusStation> GetBusStationByIdAsync(string stationId)
        {
            return await _context.BusStations.FindAsync(stationId);
        }

        public async Task<bool> UpdateBusStationStatusAsync(string busStationId, bool status)
        {
            var station = await _context.BusStations.FindAsync(busStationId);
            if (station == null) return false;

            station.Status = status;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateBusStationAsync(BusStation busStation)
        {

            _context.BusStations.Update(busStation);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<BusStation>> GetBusStationsByNameAsync(string stationName)
        {
            return await _context.BusStations
                .Where(bs => bs.BusStationName == stationName)
                .ToListAsync();
        }
        public async Task<bool> DeleteBusStationByIdAsync(string BusStationId)
        {
            var busStation = await _context.BusStations.FindAsync(BusStationId);
            if (busStation == null) return false;

            _context.BusStations.Remove(busStation);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<BusStation>> GetAllAsync()
        {
            return await _context.BusStations.ToListAsync();
        }

    }
}

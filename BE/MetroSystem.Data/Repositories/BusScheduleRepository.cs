using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroSystem.Data.Repositories
{
    public class BusScheduleRepository : IBusScheduleRepository
    {
        private readonly MetroSystemContext _context;

        public BusScheduleRepository(MetroSystemContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBusScheduleAsync(BusSchedule busSchedule)
        {
            await _context.BusSchedules.AddAsync(busSchedule);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<BusSchedule> GetBusScheduleByIdAsync(string scheduleId)
        {
            return await _context.BusSchedules
                .Include(b => b.BusLine)
                .Include(b => b.BusStation)
                .FirstOrDefaultAsync(b => b.ScheduleId == scheduleId);
        }

        public async Task<bool> UpdateBusScheduleAsync(BusSchedule busSchedule)
        {
            _context.BusSchedules.Update(busSchedule);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<BusSchedule>> GetBusSchedulesByStationNameAsync(string stationName)
        {
            return await _context.BusSchedules
                .Include(b => b.BusLine)
                .Include(b => b.BusStation)
                .Where(b => b.BusStation.BusStationName == stationName)
                .ToListAsync();
        }
        public async Task<bool> DeleteBusLineScheduleByIdAsync(string ScheduleId)
        {
            var busLineSchedule = await _context.BusSchedules.FindAsync(ScheduleId);
            if (busLineSchedule == null) return false;

            _context.BusSchedules.Remove(busLineSchedule);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
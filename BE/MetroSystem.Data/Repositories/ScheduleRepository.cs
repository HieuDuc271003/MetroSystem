using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MetroSystem.Data.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly MetroSystemContext _context;

        public ScheduleRepository(MetroSystemContext context)
        {
            _context = context;
        }

        public async Task<bool> AddScheduleAsync(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<Schedule> GetScheduleByIdAsync(string scheduleId)
        {
            return await _context.Schedules.FirstOrDefaultAsync(s => s.ScheduleId == scheduleId);
        }

        public async Task<bool> UpdateScheduleAsync(Schedule schedule)
        {
            _context.Schedules.Update(schedule);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Schedule>> GetSchedulesByStationNameAsync(string stationName)
        {
            return await _context.Schedules
                .Include(s => s.Station)
                .Include(s => s.Line)
                .Where(s => s.Station.StationName == stationName)
                .ToListAsync();
        }

        public async Task<bool> DeleteScheduleByIdAsync(string ScheduleId)
        {
            var schedule = await _context.Schedules.FindAsync(ScheduleId);
            if (schedule == null) return false;

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

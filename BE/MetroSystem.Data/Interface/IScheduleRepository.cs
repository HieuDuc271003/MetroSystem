using MetroSystem.Data.Models;
using System.Threading.Tasks;

namespace MetroSystem.Data.Interface
{
    public interface IScheduleRepository
    {
        Task<bool> AddScheduleAsync(Schedule schedule);
        Task<Schedule> GetScheduleByIdAsync(string scheduleId);
        Task<bool> UpdateScheduleAsync(Schedule schedule);
        Task<List<Schedule>> GetSchedulesByStationNameAsync(string stationName);
        Task<bool> DeleteScheduleByIdAsync(string ScheduleId);
        Task<List<Schedule>> GetAllSchedulesAsync();

    }
}

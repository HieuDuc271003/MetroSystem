using MetroSystem.Data.RequestModel.ScheduleModel;
using System.Threading.Tasks;

namespace MetroSystem.Service.Interface
{
    public interface IScheduleService
    {
        Task<bool> AddScheduleAsync(RequestCreateSchedule request);
        Task<bool> UpdateScheduleAsync(string scheduleId, RequestUpdateSchedule request);
        Task<List<ResponseScheduleModel>> GetSchedulesByStationNameAsync(string stationName);
<<<<<<< HEAD
        Task<bool> DeleteScheduleByIdAsync(string ScheduleId);
=======
>>>>>>> e644d97 (Adjust the Admin Pages)
    }
}

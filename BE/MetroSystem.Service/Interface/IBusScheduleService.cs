using MetroSystem.Data.RequestModel.BusScheduleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Interface
{
    public interface IBusScheduleService
    {
        Task<bool> AddBusScheduleAsync(RequestCreateBusSchedule request);
        Task<bool> UpdateBusScheduleAsync(string busScheduleId, RequestUpdateBusSchedule request);
        Task<List<ResponseBusScheduleModel>> GetBusSchedulesByStationNameAsync(string stationName);
<<<<<<< HEAD
        Task<bool> DeleteBusLineScheduleByIdAsync(string ScheduleId);
=======
>>>>>>> e644d97 (Adjust the Admin Pages)
    }
}

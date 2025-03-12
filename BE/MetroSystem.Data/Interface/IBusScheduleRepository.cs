using MetroSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Interface
{
    public interface IBusScheduleRepository
    {
        Task<bool> AddBusScheduleAsync(BusSchedule busSchedule);
        Task<BusSchedule> GetBusScheduleByIdAsync(string scheduleId);
        Task<bool> UpdateBusScheduleAsync(BusSchedule busSchedule);
        Task<List<BusSchedule>> GetBusSchedulesByStationNameAsync(string stationName);
    }
}

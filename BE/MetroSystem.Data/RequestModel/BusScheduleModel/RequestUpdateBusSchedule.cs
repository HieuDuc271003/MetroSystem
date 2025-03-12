using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.RequestModel.BusScheduleModel
{
    public class RequestUpdateBusSchedule
    {

        public string BusLineId { get; set; } = null!;

        public string BusStationId { get; set; } = null!;

        public TimeOnly ArrivalTime { get; set; }

        public TimeOnly DepartureTime { get; set; }

        public string DayType { get; set; } = null!;
    }
}

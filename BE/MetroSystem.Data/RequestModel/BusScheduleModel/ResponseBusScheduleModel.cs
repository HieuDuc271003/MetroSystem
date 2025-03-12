using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.RequestModel.BusScheduleModel
{
    public class ResponseBusScheduleModel
    {
        public string ScheduleId { get; set; }

        public string BusLineName { get; set; }

        public string BusStationName { get; set; }

        public TimeOnly ArrivalTime { get; set; }

        public TimeOnly DepartureTime { get; set; }

        public string DayType { get; set; }
    }
}

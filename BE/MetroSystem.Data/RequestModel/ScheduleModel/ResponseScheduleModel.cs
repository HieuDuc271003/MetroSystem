using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.RequestModel.ScheduleModel
{
    public class ResponseScheduleModel
    {
        public string ScheduleId { get; set; } = null!;

        public string LineId { get; set; } = null!;

        public string StationName { get; set; } = null!;
        public string StationId { get; set; } = null!;
        public string LineName { get; set; } = null!;

        public TimeOnly ArrivalTime { get; set; }

        public TimeOnly DepartureTime { get; set; }
    }
}

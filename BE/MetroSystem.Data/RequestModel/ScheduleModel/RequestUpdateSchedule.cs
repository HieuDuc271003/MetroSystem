using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.RequestModel.ScheduleModel
{
    public class RequestUpdateSchedule
    {
        public string LineId { get; set; } = null!;

        public string StationId { get; set; } = null!;

        public TimeOnly ArrivalTime { get; set; }

        public TimeOnly DepartureTime { get; set; }
    }
}

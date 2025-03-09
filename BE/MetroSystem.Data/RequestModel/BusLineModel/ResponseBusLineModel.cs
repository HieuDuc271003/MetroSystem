using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.RequestModel.BusLineModel
{
    public class ResponseBusLineModel
    {
        public string BusLineId { get; set; }

        public string BusLineName { get; set; }

        public string Route { get; set; }

        public bool? Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.RequestModel.BusLineModel
{
    public class RequestCreateBusLine
    {
        public required string BusLineId { get; set; }
        public required string BusLineName { get; set; }
        public required string Route { get; set; }
    }
}

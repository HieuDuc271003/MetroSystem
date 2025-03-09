using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.RequestModel.BusLineModel
{
    public class RequestUpdateBusLine
    {
        public required string BusLineId { get; set; }
        public string BusLineName { get; set; }
        public string? Route { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.RequestModel.BusLineModel
{
    public class RequestUpdateBusLine
    {
        public string BusLineName { get; set; } = null!;
        public string? Route { get; set; }
    }
}

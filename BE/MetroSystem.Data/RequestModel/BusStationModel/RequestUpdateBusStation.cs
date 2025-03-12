using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.RequestModel.BusStationModel
{
    public class RequestUpdateBusStation
    {

        public string BusStationName { get; set; } = null!;

        public string Location { get; set; } = null!;

        public bool? Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.RequestModel.BusStationModel
{
    public class RequestCreateBusStation
    {
        public string BusStationName { get; set; }

        public string Location { get; set; }
        public double? Latitude { get; set; }  // Chuyển sang kiểu double

        public double? Longitude { get; set; }

    }
}

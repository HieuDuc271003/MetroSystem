using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Enities.NewFolder
{
    public class MetroStationResponseDto
    {
        public string StationId { get; set; }
        public string StationName { get; set; }
        public string LineId { get; set; }
        public string Location { get; set; }
        public bool Status { get; set; }
    }

}

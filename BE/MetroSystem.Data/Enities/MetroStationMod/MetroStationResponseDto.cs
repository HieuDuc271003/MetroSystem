using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Enities.NewFolder
{
    public class MetroStationResponseDto
    {
        public string StationId { get; set; } = null!;
        public string StationName { get; set; } = null!;
        public string LineId { get; set; } = null!;
        public string Location { get; set; } = null!;
        public bool Status { get; set; }
    }

}

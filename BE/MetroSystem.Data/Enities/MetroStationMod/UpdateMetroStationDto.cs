using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Enities.MetroStationMod
{
    public class UpdateMetroStationDto
    {
        public string StationName { get; set; } = null!;
        public string LineId { get; set; } = null!;
        public bool? Status { get; set; }
    }
}

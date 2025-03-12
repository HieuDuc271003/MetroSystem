using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.RequestModel.MetroLineModel
{
    public class ResponseMetroLineModel
    {
        public string LineId { get; set; } = null!;

        public string LineName { get; set; } = null!;

        public double Distance { get; set; }

        public bool? Status { get; set; }
    }
}

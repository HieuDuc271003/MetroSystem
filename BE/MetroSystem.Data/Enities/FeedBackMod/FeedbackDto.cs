using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Enities.FeedBackMod
{
    public class FeedbackDto
    {
        public string LineId { get; set; }
        public string Comment { get; set; }
        public int? Rating { get; set; }
    }

}

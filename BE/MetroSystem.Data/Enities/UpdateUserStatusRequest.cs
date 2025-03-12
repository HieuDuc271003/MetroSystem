using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Enities
{
    public class UpdateUserStatusRequest
    {
        public string Email { get; set; } = null!;
        public bool Status { get; set; 
    }
}
}

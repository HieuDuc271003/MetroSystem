using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Enities
{
    public class AuthenticationModel
    {
        public string FirebaseUid { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public string IdToken { get; set; }
    }
}

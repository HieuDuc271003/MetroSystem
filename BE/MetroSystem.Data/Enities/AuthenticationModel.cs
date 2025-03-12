using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Enities
{
    public class AuthenticationModel
    {
        public string FirebaseUid { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;

        public string IdToken { get; set; } = null!;
    }
}

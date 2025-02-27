using MetroSystem.Data.Enities;
using MetroSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Interface
{
    public interface IAuthenticationService
    {
        Task<User> AuthenticateWithGoogleAsync(string firebaseUid, string email, string name);
        string GenerateJwtToken(User user);
    }
}
 
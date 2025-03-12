using MetroSystem.Data.Enities;
using MetroSystem.Data.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OfficeOpenXml.FormulaParsing.LexicalAnalysis;

namespace MetroSystem.Service.Interface
{
    public interface IAuthenticationService
    {
        Task<(User, string, string)> AuthenticateWithGoogleAsync(string firebaseUid, string email, string name);
        Task<bool> LogoutAsync(string userId);
    }
}
 
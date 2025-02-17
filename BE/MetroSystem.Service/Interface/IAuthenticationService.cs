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
        Task<string> AuthenticationLogin(string email, string password);
        Task<string> Register(RegisterUserDto registerDto);
    }
}
 
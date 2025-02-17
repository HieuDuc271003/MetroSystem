using MetroSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Interface
{
    public interface IAuthenticationRepositories
    {
        Task<User> GetUserByEmailAsync(string email);
        Task Register(User user);
    }
}

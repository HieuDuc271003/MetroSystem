using MetroSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Interface
{
    public interface IAdminRepositories
    {
        Task UpdateStatusAsync(string email, bool status);
        Task<User> GetEmailIdAsync(string email);
    }
}

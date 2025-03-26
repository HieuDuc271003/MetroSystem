using MetroSystem.Data.Models;
<<<<<<< HEAD
using System.Collections.Generic;
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
>>>>>>> e644d97 (Adjust the Admin Pages)
using System.Threading.Tasks;

namespace MetroSystem.Data.Interface
{
    public interface IAdminRepositories
    {
        Task UpdateStatusAsync(string email, bool status);
        Task<User> GetEmailIdAsync(string email);
<<<<<<< HEAD
        Task<List<User>> GetAllUsersAsync(); 
=======
>>>>>>> e644d97 (Adjust the Admin Pages)
    }
}

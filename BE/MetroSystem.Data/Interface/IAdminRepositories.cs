using MetroSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetroSystem.Data.Interface
{
    public interface IAdminRepositories
    {
        Task UpdateStatusAsync(string email, bool status);
        Task<User> GetEmailIdAsync(string email);
        Task<List<User>> GetAllUsersAsync(); 
    }
}

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
        Task<User> GetByFirebaseUidAsync(string firebaseUid);
        Task<User> GetByEmailAsync(string email);

        Task AddAsync(User user);

        Task<User> GetByUserIdAsync(string userId);

        Task UpdateUserAsync(User user);
    }
}

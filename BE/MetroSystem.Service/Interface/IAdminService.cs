using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Interface
{
    public interface IAdminService
    {
        Task<bool> SetUserStatusAsync(string userId, bool status);
    }
}

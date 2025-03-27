using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Interface
{
    public interface IRedisService
    {
        Task SetDataAsync<T>(string key, T value, TimeSpan expiration);
        Task<T?> GetDataAsync<T>(string key);
        Task<bool> RemoveDataAsync(string key);
    }

}

using MetroSystem.Data.Models;
using MetroSystem.Service.Interface;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetroSystem.Service.Service
{
    public class RedisService : IRedisService
    {
        private readonly IDatabase _db;

        public RedisService(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase(); // Đúng
        }

        public async Task SetDataAsync<T>(string key, T value, TimeSpan expiration)
        {
            var jsonData = JsonSerializer.Serialize(value);
            await _db.StringSetAsync(key, jsonData, expiration); // Đúng
        }

        public async Task<T?> GetDataAsync<T>(string key)
        {
            var value = await _db.StringGetAsync(key); // Đúng
            return value.IsNullOrEmpty ? default : JsonSerializer.Deserialize<T>(value);
        }

        public async Task<bool> RemoveDataAsync(string key)
        {
            return await _db.KeyDeleteAsync(key); // Đúng
        }
    }
}

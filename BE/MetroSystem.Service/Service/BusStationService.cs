//using MetroSystem.Data;
//using MetroSystem.Data.Interface;
//using MetroSystem.Data.Models;
//using MetroSystem.Data.RequestModel.BusStationModel;
//using MetroSystem.Service.Interface;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MetroSystem.Service.Service
//{
//    public class BusStationService : IBusStationService
//    {
//        private readonly IBusStationRepository _busStationRepository;
//        public BusStationService(IBusStationRepository busStationRepository)
//        {
//            _busStationRepository = busStationRepository;
//        }

//        public async Task<bool> AddBusStationAsync(RequestCreateBusStation request)
//        {
//            var newStation = new BusStation
//            {
//                BusStationId = Guid.NewGuid().ToString(),
//                BusStationName = request.BusStationName,
//                Location = request.Location,
//                Latitude = request.Latitude,
//                Longitude = request.Longitude,  
//                Status = true
//            };
//            return await _busStationRepository.AddBusStationAsync(newStation);
//        }

//        public async Task<bool> UpdateBusStationStatusAsync(string busStationId, bool status)
//        {
//            var existingStation = await _busStationRepository.GetBusStationByIdAsync(busStationId);
//            if (existingStation == null) return false;

//            existingStation.Status = status;
//            return await _busStationRepository.UpdateBusStationAsync(existingStation);
//        }

//        public async Task<bool> UpdateBusStationAsync(string busStationId, RequestUpdateBusStation request)
//        {
//            var existingStation = await _busStationRepository.GetBusStationByIdAsync(busStationId);
//            if (existingStation == null)
//            {
//                return false;
//            }
//            existingStation.BusStationName = request.BusStationName;
//            existingStation.Location = request.Location;
//            existingStation.Status = request.Status;
//            return await _busStationRepository.UpdateBusStationAsync(existingStation);
//        }

//        public async Task<List<ResponseBusStationModel>> GetBusStationsByStationNameAsync(string stationName)
//        {
//            var stations = await _busStationRepository.GetBusStationsByNameAsync(stationName);
//            return stations.Select(s => new ResponseBusStationModel
//            {
//                BusStationId = s.BusStationId,
//                BusStationName = s.BusStationName,
//                Location = s.Location,
//                Status = s.Status
//            }).ToList();
//        }

//        public async Task<bool> DeleteBusStationByIdAsync(string BusStationId)
//        {
//            return await _busStationRepository.DeleteBusStationByIdAsync(BusStationId);
//        }
//    }
//}
using MetroSystem.Data;
using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using MetroSystem.Data.RequestModel.BusStationModel;
using MetroSystem.Service.Interface;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Service
{
    public class BusStationService : IBusStationService
    {
        private readonly IBusStationRepository _busStationRepository;
        private readonly IDistributedCache _cache;
        private const string CacheKey = "bus_stations";

        public BusStationService(IBusStationRepository busStationRepository, IDistributedCache cache)
        {
            _busStationRepository = busStationRepository;
            _cache = cache;
        }

        public async Task<bool> AddBusStationAsync(RequestCreateBusStation request)
        {
            var newStation = new BusStation
            {
                BusStationId = Guid.NewGuid().ToString(),
                BusStationName = request.BusStationName,
                Location = request.Location,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Status = true
            };

            var result = await _busStationRepository.AddBusStationAsync(newStation);
            if (result)
            {
                await _cache.RemoveAsync(CacheKey);
            }
            return result;
        }

        public async Task<bool> UpdateBusStationStatusAsync(string busStationId, bool status)
        {
            var existingStation = await _busStationRepository.GetBusStationByIdAsync(busStationId);
            if (existingStation == null) return false;

            existingStation.Status = status;
            var result = await _busStationRepository.UpdateBusStationAsync(existingStation);
            if (result)
            {
                await _cache.RemoveAsync(CacheKey);
            }
            return result;
        }

        public async Task<bool> UpdateBusStationAsync(string busStationId, RequestUpdateBusStation request)
        {
            var existingStation = await _busStationRepository.GetBusStationByIdAsync(busStationId);
            if (existingStation == null)
            {
                return false;
            }
            existingStation.BusStationName = request.BusStationName;
            existingStation.Location = request.Location;
            existingStation.Status = request.Status;

            var result = await _busStationRepository.UpdateBusStationAsync(existingStation);
            if (result)
            {
                await _cache.RemoveAsync(CacheKey);
            }
            return result;
        }

        public async Task<List<ResponseBusStationModel>> GetBusStationsByStationNameAsync(string stationName)
        {
            var cachedData = await _cache.GetStringAsync(CacheKey);
            List<ResponseBusStationModel> stations;
            if (!string.IsNullOrEmpty(cachedData))
            {
                stations = JsonConvert.DeserializeObject<List<ResponseBusStationModel>>(cachedData);
            }
            else
            {
                var stationEntities = await _busStationRepository.GetBusStationsByNameAsync(stationName);
                stations = stationEntities.Select(s => new ResponseBusStationModel
                {
                    BusStationId = s.BusStationId,
                    BusStationName = s.BusStationName,
                    Location = s.Location,
                    Status = s.Status
                }).ToList();

                var cacheOptions = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                };
                await _cache.SetStringAsync(CacheKey, JsonConvert.SerializeObject(stations), cacheOptions);
            }
            return stations;
        }

        public async Task<bool> DeleteBusStationByIdAsync(string BusStationId)
        {
            return await _busStationRepository.DeleteBusStationByIdAsync(BusStationId);
        }
    }
}


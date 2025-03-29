//using MetroSystem.Data.Interface;
//using MetroSystem.Data.Models;
//using MetroSystem.Data.Repositories;
//using MetroSystem.Data.RequestModel.ScheduleModel;
//using MetroSystem.Service.Interface;
//using System;
//using System.Threading.Tasks;

//namespace MetroSystem.Service.Service
//{
//    public class ScheduleService : IScheduleService
//    {
//        private readonly IScheduleRepository _scheduleRepository;

//        public ScheduleService(IScheduleRepository scheduleRepository)
//        {
//            _scheduleRepository = scheduleRepository;
//        }

//        public async Task<bool> AddScheduleAsync(RequestCreateSchedule request)
//        {
//            var newSchedule = new Schedule
//            {
//                ScheduleId = Guid.NewGuid().ToString(),
//                LineId = request.LineId,
//                StationId = request.StationId,
//                ArrivalTime = request.ArrivalTime,
//                DepartureTime = request.DepartureTime
//            };

//            return await _scheduleRepository.AddScheduleAsync(newSchedule);
//        }

//        public async Task<bool> UpdateScheduleAsync(string scheduleId, RequestUpdateSchedule request)
//        {
//            var existingSchedule = await _scheduleRepository.GetScheduleByIdAsync(scheduleId);
//            if (existingSchedule == null)
//            {
//                return false;
//            }

//            existingSchedule.LineId = string.IsNullOrEmpty(request.LineId) ? existingSchedule.LineId : request.LineId;
//            existingSchedule.StationId = string.IsNullOrEmpty(request.StationId) ? existingSchedule.StationId : request.StationId;
//            existingSchedule.ArrivalTime = request.ArrivalTime == default ? existingSchedule.ArrivalTime : request.ArrivalTime;
//            existingSchedule.DepartureTime = request.DepartureTime == default ? existingSchedule.DepartureTime : request.DepartureTime;

//            return await _scheduleRepository.UpdateScheduleAsync(existingSchedule);
//        }

//        public async Task<List<ResponseScheduleModel>> GetSchedulesByStationNameAsync(string stationName)
//        {
//            var schedules = await _scheduleRepository.GetSchedulesByStationNameAsync(stationName);
//            return schedules.Select(s => new ResponseScheduleModel
//            {
//                ScheduleId = s.ScheduleId,
//                LineName = s.Line.LineName,
//                StationName = s.Station.StationName,
//                ArrivalTime = s.ArrivalTime,
//                DepartureTime = s.DepartureTime
//            }).ToList();
//        }

//        public async Task<bool> DeleteScheduleByIdAsync(string ScheduleId)
//        {
//            return await _scheduleRepository.DeleteScheduleByIdAsync(ScheduleId);
//        }

//        public async Task<List<ResponseScheduleModel>> GetAllSchedulesAsync()
//        {
//            var schedules = await _scheduleRepository.GetAllSchedulesAsync();
//            return schedules.Select(s => new ResponseScheduleModel
//            {
//                ScheduleId = s.ScheduleId,
//                LineName = s.Line.LineName,
//                StationName = s.Station.StationName,
//                ArrivalTime = s.ArrivalTime,
//                DepartureTime = s.DepartureTime
//            }).ToList();
//        }
//    }
//}
using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using MetroSystem.Data.RequestModel.ScheduleModel;
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
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IDistributedCache _cache;
        private const string CacheKey = "schedules";

        public ScheduleService(IScheduleRepository scheduleRepository, IDistributedCache cache)
        {
            _scheduleRepository = scheduleRepository;
            _cache = cache;
        }

        public async Task<bool> AddScheduleAsync(RequestCreateSchedule request)
        {
            var newSchedule = new Schedule
            {
                ScheduleId = Guid.NewGuid().ToString(),
                LineId = request.LineId,
                StationId = request.StationId,
                ArrivalTime = request.ArrivalTime,
                DepartureTime = request.DepartureTime
            };

            var result = await _scheduleRepository.AddScheduleAsync(newSchedule);
            if (result)
            {
                await _cache.RemoveAsync(CacheKey);
            }
            return result;
        }

        public async Task<bool> UpdateScheduleAsync(string scheduleId, RequestUpdateSchedule request)
        {
            var existingSchedule = await _scheduleRepository.GetScheduleByIdAsync(scheduleId);
            if (existingSchedule == null)
            {
                return false;
            }

            existingSchedule.LineId = string.IsNullOrEmpty(request.LineId) ? existingSchedule.LineId : request.LineId;
            existingSchedule.StationId = string.IsNullOrEmpty(request.StationId) ? existingSchedule.StationId : request.StationId;
            existingSchedule.ArrivalTime = request.ArrivalTime == default ? existingSchedule.ArrivalTime : request.ArrivalTime;
            existingSchedule.DepartureTime = request.DepartureTime == default ? existingSchedule.DepartureTime : request.DepartureTime;

            var result = await _scheduleRepository.UpdateScheduleAsync(existingSchedule);
            if (result)
            {
                await _cache.RemoveAsync(CacheKey);
            }
            return result;
        }

        public async Task<List<ResponseScheduleModel>> GetSchedulesByStationNameAsync(string stationName)
        {
            var schedules = await _scheduleRepository.GetSchedulesByStationNameAsync(stationName);
            return schedules.Select(s => new ResponseScheduleModel
            {
                ScheduleId = s.ScheduleId,
                LineName = s.Line.LineName,
                StationName = s.Station.StationName,
                ArrivalTime = s.ArrivalTime,
                DepartureTime = s.DepartureTime
            }).ToList();
        }

        public async Task<bool> DeleteScheduleByIdAsync(string ScheduleId)
        {
            return await _scheduleRepository.DeleteScheduleByIdAsync(ScheduleId);
        }

        public async Task<List<ResponseScheduleModel>> GetAllSchedulesAsync()
        {
            var cachedData = await _cache.GetStringAsync(CacheKey);
            if (!string.IsNullOrEmpty(cachedData))
            {
                return JsonConvert.DeserializeObject<List<ResponseScheduleModel>>(cachedData);
            }

            var schedules = await _scheduleRepository.GetAllSchedulesAsync();
            var responseList = schedules.Select(s => new ResponseScheduleModel
            {
                ScheduleId = s.ScheduleId,
                LineName = s.Line.LineName,
                StationName = s.Station.StationName,
                ArrivalTime = s.ArrivalTime,
                DepartureTime = s.DepartureTime
            }).ToList();

            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };
            await _cache.SetStringAsync(CacheKey, JsonConvert.SerializeObject(responseList), cacheOptions);

            return responseList;
        }
    }
}


using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using MetroSystem.Data.RequestModel.BusScheduleModel;
using MetroSystem.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroSystem.Service.Service
{
    public class BusScheduleService : IBusScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BusScheduleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddBusScheduleAsync(RequestCreateBusSchedule request)
        {
            var newBusSchedule = new BusSchedule
            {
                ScheduleId = Guid.NewGuid().ToString(),
                BusLineId = request.BusLineId,
                BusStationId = request.BusStationId,
                ArrivalTime = request.ArrivalTime,
                DepartureTime = request.DepartureTime,
                DayType = request.DayType
            };

            var result = await _unitOfWork.BusSchedule.AddBusScheduleAsync(newBusSchedule);
            if (result)
            {
                await _unitOfWork.SaveChangesAsync();
            }
            return result;
        }

        public async Task<bool> UpdateBusScheduleAsync(string busScheduleId, RequestUpdateBusSchedule request)
        {
            var existingSchedule = await _unitOfWork.BusSchedule.GetBusScheduleByIdAsync(busScheduleId);
            if (existingSchedule == null)
                return false;

            existingSchedule.BusLineId = request.BusLineId;
            existingSchedule.BusStationId = request.BusStationId;
            existingSchedule.ArrivalTime = request.ArrivalTime;
            existingSchedule.DepartureTime = request.DepartureTime;
            existingSchedule.DayType = request.DayType;

            var result = await _unitOfWork.BusSchedule.UpdateBusScheduleAsync(existingSchedule);
            if (result)
            {
                await _unitOfWork.SaveChangesAsync();
            }
            return result;
        }

        public async Task<List<ResponseBusScheduleModel>> GetBusSchedulesByStationNameAsync(string stationName)
        {
            var schedules = await _unitOfWork.BusSchedule.GetBusSchedulesByStationNameAsync(stationName);
            return schedules.Select(s => new ResponseBusScheduleModel
            {
                ScheduleId = s.ScheduleId,
                BusLineName = s.BusLine.BusLineName,
                BusStationName = s.BusStation.BusStationName,
                ArrivalTime = s.ArrivalTime,
                DepartureTime = s.DepartureTime,
                DayType = s.DayType
            }).ToList();
        }

        public async Task<bool> DeleteBusLineScheduleByIdAsync(string ScheduleId)
        {
            return await _unitOfWork.BusSchedule.DeleteBusLineScheduleByIdAsync(ScheduleId);
        }



    }
}
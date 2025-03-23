using MetroSystem.Data;
using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using MetroSystem.Data.RequestModel.BusStationModel;
using MetroSystem.Service.Interface;
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
        public BusStationService(IBusStationRepository busStationRepository)
        {
            _busStationRepository = busStationRepository;
        }

        public async Task<bool> AddBusStationAsync(RequestCreateBusStation request)
        {
            var newStation = new BusStation
            {
                BusStationId = Guid.NewGuid().ToString(),
                BusStationName = request.BusStationName,
                Location = request.Location,
                Status = true
            };
            return await _busStationRepository.AddBusStationAsync(newStation);
        }

        public async Task<bool> UpdateBusStationStatusAsync(string busStationId, bool status)
        {
            var existingStation = await _busStationRepository.GetBusStationByIdAsync(busStationId);
            if (existingStation == null) return false;

            existingStation.Status = status;
            return await _busStationRepository.UpdateBusStationAsync(existingStation);
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
            return await _busStationRepository.UpdateBusStationAsync(existingStation);
        }

        public async Task<List<ResponseBusStationModel>> GetBusStationsByStationNameAsync(string stationName)
        {
            var stations = await _busStationRepository.GetBusStationsByNameAsync(stationName);
            return stations.Select(s => new ResponseBusStationModel
            {
                BusStationId = s.BusStationId,
                BusStationName = s.BusStationName,
                Location = s.Location,
                Status = s.Status
            }).ToList();
        }

        public async Task<bool> DeleteBusStationByIdAsync(string BusStationId)
        {
            return await _busStationRepository.DeleteBusStationByIdAsync(BusStationId);
        }
    }
}

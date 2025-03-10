using MetroSystem.Data.Enities.MetroStationMod;
using MetroSystem.Data.Enities.NewFolder;
using MetroSystem.Data.Models;
using MetroSystem.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Service
{
    public class MetroStationService : IMetroStationService
    {
        private readonly IMetroStationRepository _metroStationRepository;
        public MetroStationService(IMetroStationRepository metroStationRepository)
        {
            _metroStationRepository = metroStationRepository;
        }

        public async Task<IEnumerable<MetroStationResponseDto>> GetAllStationsAsync()
        {
            var stations = await _metroStationRepository.GetAllAsync();
            return stations.Select(station => new MetroStationResponseDto
            {
                StationId = station.StationId,
                StationName = station.StationName,
                LineId = station.LineId,
                Location = station.Location,
                Status = (bool)station.Status
            });
        }

        public async Task<(bool IsSuccess, string Message, MetroStationResponseDto Station)> GetStationByNameAsync(string stationName) // 🔹 Đổi từ GetByIdAsync thành GetByStationNameAsync
        {
            var station = await _metroStationRepository.GetByStationNameAsync(stationName);
            if (station == null)
            {
                return (false, "Metro station not found.", null);
            }

            return (true, "Metro station retrieved successfully.", new MetroStationResponseDto
            {
                StationId = station.StationId,
                StationName = station.StationName,
                LineId = station.LineId,
                Location = station.Location,
                Status = (bool)station.Status
            });
        }

        public async Task<(bool IsSuccess, string Message, MetroStationResponseDto Station)> CreateStationAsync(MetroStationDto request)
        {
            try
            {
                var newStation = new MetroStation
                {
                    StationId = Guid.NewGuid().ToString(),
                    StationName = request.StationName,
                    LineId = request.LineId,
                    Location = request.Location,
                    Status = request.Status
                };

                await _metroStationRepository.AddAsync(newStation);
                await _metroStationRepository.SaveChangesAsync();

                return (true, "Metro station added successfully.", new MetroStationResponseDto
                {
                    StationId = newStation.StationId,
                    StationName = newStation.StationName,
                    LineId = newStation.LineId,
                    Location = newStation.Location,
                    Status = (bool)newStation.Status
                });
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}", null);
            }
        }

        public async Task<(bool IsSuccess, string Message, MetroStationResponseDto Station)> UpdateStationAsync(string stationId, UpdateMetroStationDto request)
        {
            var station = await _metroStationRepository.GetByIdAsync(stationId);
            if (station == null)
            {
                return (false, "Metro station not found.", null);
            }

            // Cập nhật giá trị
            station.StationName = request.StationName ?? station.StationName;
            station.LineId = request.LineId ?? station.LineId;
            station.Status = request.Status ?? station.Status;

            await _metroStationRepository.SaveChangesAsync();

            return (true, "Metro station updated successfully.", new MetroStationResponseDto
            {
                StationId = station.StationId,
                StationName = station.StationName,
                LineId = station.LineId,
                Location = station.Location,
                Status = (bool)station.Status
            });
        }
    }
}
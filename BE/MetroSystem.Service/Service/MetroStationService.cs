﻿using MetroSystem.Data.Enities.MetroStationMod;
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
        private readonly IGeocodingService _geocodingService;

        public MetroStationService(IMetroStationRepository metroStationRepository, IGeocodingService geocodingService)
        {
            _metroStationRepository = metroStationRepository;
            _geocodingService = geocodingService;   
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

        public async Task<List<MetroStationDistanceDto>> GetNearestStationsAsync(string address, int limit = 10)
        {
            var (userLat, userLng) = await _geocodingService.GetCoordinatesAsync(address);
            Console.WriteLine($"User Location: Lat={userLat}, Lng={userLng}");

            var stations = await _metroStationRepository.GetAllAsync();

            var nearestStations = stations
                .Select(station =>
                {
                    double distance = CalculateDistance(userLat, userLng, station.Latitude, station.Longitude);
                    Console.WriteLine($"Distance from {address} to {station.StationName}: {distance} km");

                    return new
                    {
                        Station = station,
                        Distance = distance
                    };
                })
                .OrderBy(s => s.Distance)
                .Take(limit)
                .Select(s => new MetroStationDistanceDto
                {
                    StationName = s.Station.StationName,
                    Latitude = s.Station.Latitude,
                    Longitude = s.Station.Longitude,
                    Distance = s.Distance
                })
                .ToList();

            return nearestStations;
        }

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            Console.WriteLine($"Calculating Distance: From ({lat1}, {lon1}) To ({lat2}, {lon2})");

            const double R = 6371; // Bán kính Trái Đất (km)
            double dLat = DegreesToRadians(lat2 - lat1);
            double dLon = DegreesToRadians(lon2 - lon1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = R * c;

            Console.WriteLine($"Calculated Distance: {distance} km");
            return distance;
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }
    }
}
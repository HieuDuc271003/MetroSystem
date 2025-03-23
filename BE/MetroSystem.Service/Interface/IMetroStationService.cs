using MetroSystem.Data.Enities.MetroStationMod;
using MetroSystem.Data.Enities.NewFolder;
using MetroSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Interface
{
    public interface IMetroStationService
    {
        Task<IEnumerable<MetroStationResponseDto>> GetAllStationsAsync();
        Task<(bool IsSuccess, string Message, MetroStationResponseDto Station)> GetStationByNameAsync(string stationName);

        Task<(bool IsSuccess, string Message, MetroStationResponseDto Station)> CreateStationAsync(MetroStationDto request);

        Task<(bool IsSuccess, string Message, MetroStationResponseDto Station)> UpdateStationAsync(string stationId, UpdateMetroStationDto request);

        Task<List<MetroStationDistanceDto>> GetNearestStationsAsync(string address, int limit = 10);
        Task<bool> DeleteMetroStationByIdAsync(string StationId);
    }

}

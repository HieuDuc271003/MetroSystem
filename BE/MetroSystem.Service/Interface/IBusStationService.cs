using MetroSystem.Data.RequestModel.BusStationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Interface
{
    public interface IBusStationService
    {
        Task<bool> AddBusStationAsync(RequestCreateBusStation request);
        Task<bool> UpdateBusStationAsync(string busStationId, RequestUpdateBusStation request);
        Task<bool> UpdateBusStationStatusAsync(string busStationId, bool status);
        Task<List<ResponseBusStationModel>> GetBusStationsByStationNameAsync(string stationName);
        Task<bool> DeleteBusStationByIdAsync(string BusStationId);
    }
}

using MetroSystem.Data.RequestModel.BusLineModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Interface
{
    public interface IBusLineService
    {
        Task<bool> AddBusLineAsync(RequestCreateBusLine requestCreateBusLine);
        Task<bool> UpdateBusLineStatusAsync(string busLineId, bool status);
        Task<bool> UpdateBusLineDetailsAsync(string busLineId, RequestUpdateBusLine requestUpdateBusLine);
        Task<IEnumerable<ResponseBusLineModel>> GetAllBusLinesAsync();
        Task<ResponseBusLineModel?> GetBusLineByNameAsync(string busLineName);

    }
}

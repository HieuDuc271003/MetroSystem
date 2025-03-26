using MetroSystem.Data.Enities;
using MetroSystem.Data.Models;
using MetroSystem.Data.RequestModel.MetroLineModel;
using MetroSystem.RequestModel.MetroLineModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Interface
{
    public interface IMetroLineService
    {
        Task<bool> AddMetroLineAsync(RequestCreateMetroLine requestCreateMetroLine);
        Task<bool> UpdateMetroLineStatusAsync(string lineId, bool status);
        Task<bool> UpdateMetroLineDetailsAsync(string lineId, RequestUpdateMetroLine requestUpdateMetroLine);
        Task<IEnumerable<ResponseMetroLineModel>> GetAllMetroLinesAsync();
        Task<ResponseMetroLineModel?> GetMetroLineByNameAsync(string lineName);
<<<<<<< HEAD
        Task<bool> DeleteMetroLineByIdAsync(string LineId);
=======
>>>>>>> e644d97 (Adjust the Admin Pages)

    }
}

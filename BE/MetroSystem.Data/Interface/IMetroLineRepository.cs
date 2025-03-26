using MetroSystem.RequestModel.MetroLineModel;
using MetroSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Interface
{
    public interface IMetroLineRepository
    {
        Task AddMetroLineAsync(MetroLine metroLine);
        Task<MetroLine> GetMetroLineByIdAsync(string lineId);
        Task<IEnumerable<MetroLine>> GetAllMetroLinesAsync(); // Thêm phương thức lấy tất cả tuyến metro
        Task<MetroLine?> GetMetroLineByNameAsync(string lineName);
<<<<<<< HEAD
        Task<bool> DeleteMetroLineByIdAsync(string LineId);
=======
>>>>>>> e644d97 (Adjust the Admin Pages)
    }
}

using MetroSystem.Data.Models;
using System.Threading.Tasks;

namespace MetroSystem.Data.Interface
{
    public interface IBusLineRepository
    {
        Task AddAsync(BusLine busLine);
        Task<BusLine> GetBusLineByIdAsync(string busLineId);
        Task<IEnumerable<BusLine>> GetAllBusLinesAsync();
        Task<BusLine?> GetBusLineByNameAsync(string busLineName);
    }
}

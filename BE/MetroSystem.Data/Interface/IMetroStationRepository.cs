using MetroSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Interface
{
    public interface IMetroStationRepository
    {
        Task<IEnumerable<MetroStation>> GetAllAsync();
        Task<MetroStation> GetByStationNameAsync(string stationName);
        Task AddAsync(MetroStation station);
        Task<bool> SaveChangesAsync();

        Task<MetroStation> GetByIdAsync(string stationId);


    }
}

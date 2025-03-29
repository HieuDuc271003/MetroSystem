using MetroSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Interface
{
    public interface IBusStationMetroRepository
    {
        Task AddAsync(BusStationMetroStation record);
    }
}

using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Repositories
{
    public class BusStationMetroRepository : IBusStationMetroRepository
    {
        private readonly MetroSystemContext _context;

        public BusStationMetroRepository(MetroSystemContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BusStationMetroStation record)
        {
            _context.BusStationMetroStations.Add(record);
            await _context.SaveChangesAsync();
        }
    }
}

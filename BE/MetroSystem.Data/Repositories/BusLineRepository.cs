using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Repositories
{
    public class BusLineRepository : IBusLineRepository
    {
        private readonly MetroSystemContext _context;

        public BusLineRepository(MetroSystemContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BusLine busLine)
        {
            await _context.BusLines.AddAsync(busLine);
        }

        public async Task<BusLine> GetBusLineByIdAsync(string busLineId)
        {
            return await _context.BusLines.FirstOrDefaultAsync(b => b.BusLineId == busLineId);
        }
        public async Task<IEnumerable<BusLine>> GetAllBusLinesAsync()
        {
            return await _context.BusLines.ToListAsync();
        }

        public async Task<BusLine?> GetBusLineByNameAsync(string busLineName)
        {
            return await _context.BusLines.FirstOrDefaultAsync(b => b.BusLineName == busLineName);
        }
<<<<<<< HEAD
        public async Task<bool> DeleteBusLineByIdAsync(string busLineId)
        {
            var busLine = await _context.BusLines.FindAsync(busLineId);
            if (busLine == null) return false;

            _context.BusLines.Remove(busLine);
            await _context.SaveChangesAsync();
            return true;
        }
=======
>>>>>>> e644d97 (Adjust the Admin Pages)
    }
}

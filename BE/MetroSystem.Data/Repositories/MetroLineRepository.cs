using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using MetroSystem.RequestModel.MetroLineModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Repositories
{
    public class MetroLineRepository : IMetroLineRepository
    {
        private readonly MetroSystemContext _context;

        public MetroLineRepository(MetroSystemContext context)
        {
            _context = context;
        }

        public async Task AddMetroLineAsync(MetroLine metroLine)
        {
            await _context.MetroLines.AddAsync(metroLine);
        }
        public async Task<MetroLine> GetMetroLineByIdAsync(string lineId)
        {
            return await _context.MetroLines.FirstOrDefaultAsync(m => m.LineId == lineId);
        }
        public async Task<IEnumerable<MetroLine>> GetAllMetroLinesAsync()
        {
            return await _context.MetroLines.ToListAsync();
        }

        public async Task<MetroLine?> GetMetroLineByNameAsync(string lineName)
        {
            return await _context.MetroLines.FirstOrDefaultAsync(m => m.LineName == lineName);
        }
    }
}

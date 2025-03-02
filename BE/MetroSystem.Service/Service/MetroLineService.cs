using MetroSystem.Data.Enities;
using MetroSystem.Data.Interface;
using MetroSystem.Service.Interface;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroSystem.Data.Models;
using MetroSystem.RequestModel.MetroLineModel;

namespace MetroSystem.Service.Service
{
    public class MetroLineService : IMetroLineService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MetroLineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddMetroLineAsync(RequestCreateMetroLine requestCreateMetroLine)
        {
            var metroLine = new MetroLine
            {
                LineId = requestCreateMetroLine.LineId,
                LineName = requestCreateMetroLine.LineName,
                Distance = requestCreateMetroLine.Distance,
                Status = true 
            };

            await _unitOfWork.MetroLine.AddMetroLineAsync(metroLine);
            await _unitOfWork.SaveChangesAsync();
            return true;

            
        }
    }
}

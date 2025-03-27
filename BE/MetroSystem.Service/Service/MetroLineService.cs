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
using MetroSystem.Data.RequestModel.MetroLineModel;
using Microsoft.EntityFrameworkCore;
using MetroSystem.Data.Repositories;

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
                LineId = Guid.NewGuid().ToString(),
                LineName = requestCreateMetroLine.LineName,
                Distance = requestCreateMetroLine.Distance,
                Status = true 
            };

            await _unitOfWork.MetroLine.AddMetroLineAsync(metroLine);
            await _unitOfWork.SaveChangesAsync();
            return true;

            
        }
        public async Task<bool> UpdateMetroLineStatusAsync(string lineId, bool status)
        {
            var metroLine = await _unitOfWork.MetroLine.GetMetroLineByIdAsync(lineId);
            if (metroLine == null) return false;

            metroLine.Status = status;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateMetroLineDetailsAsync(string lineId, RequestUpdateMetroLine requestUpdateMetroLine)
        {
            var metroLine = await _unitOfWork.MetroLine.GetMetroLineByIdAsync(lineId);
            if (metroLine == null) return false;

            if (!string.IsNullOrEmpty(requestUpdateMetroLine.LineName))
                metroLine.LineName = requestUpdateMetroLine.LineName;

            if (requestUpdateMetroLine.Distance.HasValue)
                metroLine.Distance = requestUpdateMetroLine.Distance.Value;

            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ResponseMetroLineModel>> GetAllMetroLinesAsync()
        {
            return (await _unitOfWork.MetroLine.GetAllMetroLinesAsync())             
                .Select(m => new ResponseMetroLineModel
                {
                    LineId = m.LineId,
                    LineName = m.LineName,
                    Distance = m.Distance,
                    Status = m.Status
                })
                .ToList();
        }

        public async Task<ResponseMetroLineModel?> GetMetroLineByNameAsync(string lineName)
        {
            var metroLine = await _unitOfWork.MetroLine.GetMetroLineByNameAsync(lineName);
            if (metroLine == null) return null;

            return new ResponseMetroLineModel
            {
                LineId = metroLine.LineId,
                LineName = metroLine.LineName,
                Distance = metroLine.Distance,
                Status = metroLine.Status
            };
        }

        public async Task<bool> DeleteMetroLineByIdAsync(string LineId)
        {
            return await _unitOfWork.MetroLine.DeleteMetroLineByIdAsync(LineId);
        }

    }
}

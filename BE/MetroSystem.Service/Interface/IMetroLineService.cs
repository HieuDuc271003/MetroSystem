using MetroSystem.Data.Enities;
using MetroSystem.Data.Models;
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

    }
}

using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
<<<<<<< HEAD
using MetroSystem.Data.Repositories;
=======
>>>>>>> e644d97 (Adjust the Admin Pages)
using MetroSystem.Data.RequestModel.BusLineModel;
using MetroSystem.Service.Interface;
using System.Threading.Tasks;

namespace MetroSystem.Service.Service
{
    public class BusLineService : IBusLineService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BusLineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddBusLineAsync(RequestCreateBusLine requestCreateBusLine)
        {
            var newBusLine = new BusLine
            {
                BusLineId = Guid.NewGuid().ToString(),
                BusLineName = requestCreateBusLine.BusLineName,
                Route = requestCreateBusLine.Route,
                Status = true
            };

            await _unitOfWork.BusLine.AddAsync(newBusLine);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBusLineStatusAsync(string busLineId, bool status)
        {
            var busLine = await _unitOfWork.BusLine.GetBusLineByIdAsync(busLineId);
            if (busLine == null) return false;

            busLine.Status = status;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBusLineDetailsAsync(string busLineId, RequestUpdateBusLine requestUpdateBusLine)
        {
            var busLine = await _unitOfWork.BusLine.GetBusLineByIdAsync(busLineId);
            if (busLine == null) return false;

            if (!string.IsNullOrEmpty(requestUpdateBusLine.BusLineName))
                busLine.BusLineName = requestUpdateBusLine.BusLineName;

            if (!string.IsNullOrEmpty(requestUpdateBusLine.Route))
                busLine.Route = requestUpdateBusLine.Route;

            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ResponseBusLineModel>> GetAllBusLinesAsync()
        {
            return (await _unitOfWork.BusLine.GetAllBusLinesAsync())
                .Select(b => new ResponseBusLineModel
                {
                    BusLineId = b.BusLineId,
                    BusLineName = b.BusLineName,
                    Route = b.Route,
                    Status = b.Status
                }).ToList();
        }

        public async Task<ResponseBusLineModel?> GetBusLineByNameAsync(string busLineName)
        {
            var busLine = await _unitOfWork.BusLine.GetBusLineByNameAsync(busLineName);
            if (busLine == null) return null;

            return new ResponseBusLineModel
            {
                BusLineId = busLine.BusLineId,
                BusLineName = busLine.BusLineName,
                Route = busLine.Route,
                Status = busLine.Status
            };
        }
<<<<<<< HEAD
        public async Task<bool> DeleteBusLineByIdAsync(string busLineId)
        {
            return await _unitOfWork.BusLine.DeleteBusLineByIdAsync(busLineId);
        }
=======
>>>>>>> e644d97 (Adjust the Admin Pages)
    }
}

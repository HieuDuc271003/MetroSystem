using MetroSystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Interface
{
    //public interface IUnitOfWork : IDisposable
    //{
    //    IAuthenticationRepositories Authentication { get; }
    //    IAdminRepositories Admin { get; }
    //    Task<int> SaveChangesAsync();
    //}
    public interface IUnitOfWork : IDisposable
    {
        IAuthenticationRepositories Authentication { get; }
        IAdminRepositories Admin { get; }
        IMetroLineRepository MetroLine { get; } // ✨ Thêm mới repository quản lý chuyến tàu
        IBusLineRepository BusLine { get; } // ✨ Thêm mới repository quản lý chuyến xe buýt
        IScheduleRepository Schedule { get; }
        IBusScheduleRepository BusSchedule { get; }
        IBusStationRepository BusStation { get; }

        Task<int> SaveChangesAsync();
    }

}

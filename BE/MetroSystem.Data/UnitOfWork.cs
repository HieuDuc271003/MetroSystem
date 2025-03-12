using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
using MetroSystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data
{
    //public class UnitOfWork : IUnitOfWork
    //{
    //    private readonly MetroSystemContext _context;
    //    public IAuthenticationRepositories Authentication { get; }
    //    public IAdminRepositories Admin { get; }

    //    public UnitOfWork(MetroSystemContext context, IAuthenticationRepositories authenticationRepositories, IAdminRepositories adminRepositories)
    //    {
    //        _context = context;
    //        Authentication = authenticationRepositories;
    //        Admin = adminRepositories;
    //    }

    //    public async Task<int> SaveChangesAsync()
    //    {
    //        return await _context.SaveChangesAsync();
    //    }

    //    public void Dispose()
    //    {
    //        _context.Dispose();
    //    }

    //}
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MetroSystemContext _context;
        public IAuthenticationRepositories Authentication { get; }
        public IAdminRepositories Admin { get; }
        public IMetroLineRepository MetroLine { get; }
        public IBusLineRepository BusLine { get; }
        public IScheduleRepository Schedule { get; }
        public IBusScheduleRepository BusSchedule { get; }
        public IBusStationRepository BusStation { get; }


        public UnitOfWork(MetroSystemContext context, IAuthenticationRepositories authenticationRepositories, IAdminRepositories adminRepositories, IMetroLineRepository metroLineRepository, IBusLineRepository busLineRepository, IScheduleRepository scheduleRepository, IBusScheduleRepository busScheduleRepository, IBusStationRepository busStationRepository)
        {
            _context = context;
            Authentication = authenticationRepositories;
            Admin = adminRepositories;
            MetroLine = metroLineRepository;
            BusLine = busLineRepository;
            Schedule = scheduleRepository;
            BusSchedule = busScheduleRepository;
            BusStation = busStationRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

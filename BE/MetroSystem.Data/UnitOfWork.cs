using MetroSystem.Data.Interface;
using MetroSystem.Data.Models;
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

        public UnitOfWork(MetroSystemContext context, IAuthenticationRepositories authenticationRepositories, IAdminRepositories adminRepositories, IMetroLineRepository metroLineRepository)
        {
            _context = context;
            Authentication = authenticationRepositories;
            Admin = adminRepositories;
            MetroLine = metroLineRepository;
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

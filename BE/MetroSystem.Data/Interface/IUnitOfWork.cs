using MetroSystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthenticationRepositories Authentication { get; }
        IAdminRepositories Admin { get; }
        Task<int> SaveChangesAsync();
    }
}

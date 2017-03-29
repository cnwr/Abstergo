using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Core.Dal
{
    public interface IDbContext : IDisposable
    {
        IDbSet<T> Set<T>() where T : class;
        IQueryable SetAsQueryable(Type entityType);
        Task<int> SaveChangesAsync();
    }
}

using Abstergo.Core.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Dal
{
    public class AbstergoDbContext : IDbContext
    {
        public AbstergoDbContext(string connection) 
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public IDbSet<T> Set<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable SetAsQueryable(Type entityType)
        {
            throw new NotImplementedException();
        }
    }
}

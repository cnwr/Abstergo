using Abstergo.Core.Dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Dal
{
    public class AbstergoContext : DbContext, IAbstergoContext
    {
        public AbstergoContext() : base("AbstergoConnection")
        {

        }

        Core.Dal.IDbSet<T> IDbContext.Set<T>()
            => new DbSet<T>(Set<T>());

        public IQueryable SetAsQueryable(Type entityType)
        {
            return Set(entityType);
        }
    }
}

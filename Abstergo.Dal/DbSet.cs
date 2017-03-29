using Abstergo.Core.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Dal
{
    class DbSet<TEntity> : Core.Dal.IDbSet<TEntity>
       where TEntity : class
    {
        private readonly System.Data.Entity.DbSet<TEntity> _set;

        public DbSet(System.Data.Entity.DbSet<TEntity> set)
        {
            _set = set;
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _set;
        }

        public IQueryable<TEntity> AsQueryableWithNoTracking()
        {
            return _set.AsNoTracking();
        }
    }
}

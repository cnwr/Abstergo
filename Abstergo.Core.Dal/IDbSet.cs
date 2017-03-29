using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Core.Dal
{
    public interface IDbSet<T> where T : class
    {
        IQueryable<T> AsQueryable();
        IQueryable<T> AsQueryableWithNoTracking();
    }
}

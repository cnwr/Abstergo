using Abstergo.Entities.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Core.Service
{
    public interface IUserService
    {
        Task<IEnumerable<ArgsUser>> GetUsersAsync();
    }
}

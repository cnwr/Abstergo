using Abstergo.Core.Service;
using Abstergo.Entities.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Imp.Service
{
    public class UserService : IUserService
    {
        public async Task<IEnumerable<ArgsUser>> GetUsersAsync()
        {
            return new List<ArgsUser>();
        }
    }
}

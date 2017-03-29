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
        public Task<string> GetUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ArgsUser>> GetUsersAsync()
        {
            var list = new List<ArgsUser>();
            for (var i = 0; i < 20; i++)
            {
                var a = new ArgsUser
                {
                    UserId = i,
                    UserName = "username" + i,
                    FirstName = "firstname" + i,
                    LastName = "lastname" + i
                };
                list.Add(a);
            }
            return list;
        }
    }
}

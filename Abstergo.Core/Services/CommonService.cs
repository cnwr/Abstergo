using Abstergo.Core.Common;
using Abstergo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Core.Services
{
    public class CommonService : ICommon
    {
        public string HashPassword()
        {
            return PasswordManager.HashPassword("adsad");
        }
    }
}

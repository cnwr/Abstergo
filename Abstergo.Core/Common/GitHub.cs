using Abstergo.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Core.Common
{
    class GitHub
    {
        [TestMethod("Henuz yazilmadi")]
        public bool PushGithub(string name ,out string gokhanow) {
            gokhanow = name;
            return true;
        }  
    }
}

using Abstergo.Dal.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abstergo.Dal
{
    public class UserModel:BaseModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}

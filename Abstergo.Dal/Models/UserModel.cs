﻿using Abstergo.Dal.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abstergo.Dal
{
    public class UserModel:BaseModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

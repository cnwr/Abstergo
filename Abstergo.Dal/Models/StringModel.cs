using Abstergo.Dal.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abstergo.Dal
{
    public class StringModel : BaseModel
    {
        public string Code { get; set; }
        public string Value { get; set; }
        public string Lang { get; set; }
    }
}

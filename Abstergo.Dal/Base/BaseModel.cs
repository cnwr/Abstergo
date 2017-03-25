using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abstergo.Dal.Base
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateDate{ get; set; }
        public bool IsActive { get; set; }
    }
}

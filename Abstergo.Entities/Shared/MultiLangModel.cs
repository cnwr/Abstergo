using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Entities.Shared
{
    public class MultiLangModel
    {
        public int Id { get; set; }
        public string Culture { get; set; }
        public string Value { get; set; }
    }
}

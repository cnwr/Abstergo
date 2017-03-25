using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Entities.Shared
{
    public class MethodDefinition
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Version { get; set; } = "0.0.0";
        public string TestMethodName { get; set; }
    }
}

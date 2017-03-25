using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Entities.Shared
{
    [Serializable]
    public class AzureMessage
    {
        public long Id{ get; set; }
        public string Body { get; set; }
    }
}

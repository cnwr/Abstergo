using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Entities.Shared
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class TestMethod : Attribute
    {
        private string _description;

        public TestMethod(string description)
        {
            this._description = description;
        }

        public string Description
        {
            get { return _description; }
        }
    }
}



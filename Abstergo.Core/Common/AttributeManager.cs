using Abstergo.Entities.Shared;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Core.Common
{
    class AttributeManager
    {
        public List<MethodDefinition> GetTestMethodsList()
        {
            int count = 1;
            List<MethodDefinition> mdList = new List<MethodDefinition>();

            foreach (Type type in Assembly.Load("Abstergo").GetTypes())
            {
                MethodInfo[] mi = type.GetMethods();

                foreach (var m in mi)
                {
                    var att = m.GetCustomAttribute(typeof(TestMethod), true);
                    if (att != null)
                    {
                        TestMethod tm = (TestMethod)att;
                        MethodDefinition md = new MethodDefinition()
                        {
                            Name = m.Name,
                            Description = tm.Description,
                            Code = count.ToString(),
                            TestMethodName = "Test" + m.Name
                        };

                        mdList.Add(md);
                        count++;
                    }
                }
            }
            return mdList;
        }
    }
}

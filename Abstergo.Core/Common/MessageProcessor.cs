using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Core
{
    public class MessageProcessor
    {
        public static void Caller(string myclass, string mymethod, object param)
        {
            var par = new object[1];
            par[0] = param;

            var type = Assembly.Load("Abstergo.Operations").GetType("Abstergo.Operations.BusinessOperations." + myclass);
            var obj = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod(mymethod);
            methodInfo.Invoke(obj, par);
        }
    }
}

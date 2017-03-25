using Abstergo.Entities.Shared;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Core.Common
{
    class IssManager
    {
        public static List<string> AbstergoAppPools()
        {

            var list = new List<string>();
            var W3SVC = new DirectoryEntry("IIS://LocalHost/w3svc", "", "");

            foreach (DirectoryEntry Site in W3SVC.Children)
            {
                if (Site.Name == "AppPools")
                {
                    foreach (DirectoryEntry child in Site.Children)
                    {
                        list.Add(child.Name);
                    }
                }
            }
            return list;
        }

        public static void RecycleAppPool(string IIsApplicationPool)
        {
            var scope = new ManagementScope(@"\\localhost\root\MicrosoftIISv2");
            scope.Connect();

            var appPool = new ManagementObject(scope, new ManagementPath("IIsApplicationPool.Name='W3SVC/AppPools/" + IIsApplicationPool + "'"), null);

            appPool.InvokeMethod("Recycle", null, null);
        }

        public static void RecycleAppPool()
        {
            try
            {
                AbstergoAppPools().ForEach(m => RecycleAppPool(m));
            }
            catch (Exception ex)
            {
                //todo:loglama cart curt
            }
        }

        public static void RecyleIss()
        {
            System.Diagnostics.Process.Start(@"C:\Windows\System32\iisreset.exe");
        }
    }
}

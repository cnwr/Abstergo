using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Abstergo.Entities.Shared;
using Abstergo.Core.Common;

namespace Abstergo.Core
{
    public class AbstergoCore
    {
        public void Run()
        {
            ExecuteWelcomeMessage();
            ExecuteMainProgram();
        }

        private void ExecuteWelcomeMessage()
        {
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine(@"          ____   _____ _______ ______ _____   _____  ____  ");
            Console.WriteLine(@"    /\   |  _ \ / ____|__   __|  ____|  __ \ / ____|/ __ \ ");
            Console.WriteLine(@"   /  \  | |_) | (___    | |  | |__  | |__) | |  __| |  | |");
            Console.WriteLine(@"  / /\ \ |  _ < \___ \   | |  |  __| |  _  /| | |_ | |  | |");
            Console.WriteLine(@" / ____ \| |_) |____) |  | |  | |____| | \ \| |__| | |__| |");
            Console.WriteLine(@"/_/    \_\____/|_____/   |_|  |______|_|  \_\_____| \____/ ");
            Console.WriteLine();
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("********************** BY MASTER GOKHANOW  **************************");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("*********************************************************************\n\n");

            Console.WriteLine(string.Format(@"UserName: {0}\{1}", Environment.UserDomainName, Environment.UserName));
            Console.WriteLine("\n\n");

        }

        private void ExecuteMainProgram()
        {
            CacheMan.TestMethods.ForEach(m =>
              {
                  var txt = m.Code + " - " + m.Name + " (" + m.Description + ")";
                  Console.WriteLine(txt);
              });

            Console.WriteLine();
            Console.Write("->");

            var num = Console.ReadLine();
            Execute(num);
        }

        public void Execute(string num)
        {
            this.GetType().GetMethod(
                 CacheMan.TestMethods.Where(
                     a => a.Code == num
                     ).First()
                     .TestMethodName
                 ).Invoke(this, null);
        }

        public static void TestBitly()
        {
            Console.Write("- 1 For BitlyFromWebRequest\n");
            Console.Write("- 2 For BitylFromApi\n");
            var num = Console.ReadLine();

            var bitly = new Bitly();
            switch (num)
            {
                case "1":
                    bitly.BitlyFromWebRequest();
                    break;
                case "2":
                    bitly.BitylFromApi("");
                    break;
            }
        }

        public static void TestGitHub()
        {
            Console.Write("- 1 For Deneme\n");
            var num = Console.ReadLine().ToString();

            var a = "yildiz";
            var b = "gokhanow";

            var git = new GitHub();
            switch (num)
            {
                case "1":
                    if (git.PushGithub(a, out b))
                    {
                        Console.WriteLine("a =" + a);
                        Console.WriteLine("b =" + b);
                    }
                    break;
            }
        }

        public static void TestPassword()
        {
            var hashPassword = PasswordManager.HashPassword("gokhanow");

            Console.WriteLine("Password:" + "gokhanow");
            Console.WriteLine("HashPassword: " + hashPassword);
        }

        public static void TestTcpClientManager()
        {
            TcpClientManager tcm = new TcpClientManager();
            tcm.StartSending();
        }

        public static void TestImageProcessor()
        {
            ImageProcessor ip = new ImageProcessor();
            ip.GenerateQrCodeByQrCoder("deneme");
        }

        public static void TestAttributeManager()
        {
            AttributeManager atm = new AttributeManager();
            atm.GetTestMethodsList();
        }

        public static void TestSendQueueMessage()
        {
            AzureServiceBus asb = new AzureServiceBus();
            asb.SendQueueMessage();
        }

        public static void TestGetQueueMessage()
        {
            AzureServiceBus asb = new AzureServiceBus();
            asb.GetQueueMessage();
        }

        public static void TestAzureLoadTestSend()
        {
            AzureServiceBus asb = new AzureServiceBus();
            asb.AzureLoadTestSend();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Test
{
    class AbstergoMain
    {
        static void Main(string[] args)
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "ABSTERGO SHELL";

            //ExecuteAbstergo(true);

        }

        //private static Boolean ExecuteAbstergo(Boolean run)
        //{
        //    if (!run)
        //        Environment.Exit(0);

        //    try
        //    {
        //        Console.Clear();
        //        Console.Write(@"\>");

        //        var cmd = Console.ReadLine();
               
        //        switch (cmd.ToLowerInvariant())
        //        {
                     
        //            case "cls":
        //                ExecuteAbstergo(true);
        //                break;
        //            case "run":
        //                AbstergoCore ac = new AbstergoCore();
        //                ac.Run();

        //                Console.Beep();
        //                Console.WriteLine(@" Method Executed!");
        //                Console.WriteLine(@" 1 - to restart application");
        //                Console.WriteLine(@" 2 - to exit application");
        //                Console.Write(@"\>");

        //                var cm = Console.ReadLine();
        //                while (cm != "1")
        //                {
        //                    Console.Beep();
        //                    Console.WriteLine("Bad command!");
        //                    cm = Console.ReadLine();
        //                }

        //                ExecuteAbstergo(cm == "1");
        //                break;
        //            case "listen":
        //                AbstergoCore.TestTcpClientManager();
        //                break;
        //            case "bitly":
        //                AbstergoCore.TestBitly();
        //                break;
        //            default:
        //                Console.Beep();
        //                Console.WriteLine("Bad command!");
        //                ExecuteAbstergo(true);
        //                break;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(" It’s OK to have an error.");
        //        Console.WriteLine(" Please enter to restart application");
        //        Console.ReadLine();

        //    }
        //    return false;
        //}
    }
}

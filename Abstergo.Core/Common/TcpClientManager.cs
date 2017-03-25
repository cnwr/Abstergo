using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Abstergo.Entities.Shared;

namespace Abstergo.Core.Common
{
    class TcpClientManager
    {
        const int PortNo = 50000;
        const string ServerIp = "127.0.0.1";

        [TestMethod("Tcp uzerinden dinleme")]
        public void StartListening()
        {
            Console.Clear();

            var localAdd = IPAddress.Parse(ServerIp);
            var listener = new TcpListener(localAdd, PortNo);
            Console.WriteLine("Listening...");
            listener.Start();

            var res = string.Empty;
            var client = listener.AcceptTcpClient();

            while (res != "-1")
            {
                var ns = client.GetStream();
                var buffer = new byte[client.ReceiveBufferSize];

                var bytesRead = ns.Read(buffer, 0, client.ReceiveBufferSize);

                res = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                Console.WriteLine(res);
            }

            client.Close();
            listener.Stop();

            Console.ReadLine();
        }

        [TestMethod("Tcp uzerinden data aktarma")]
        public void StartSending()
        {
            var client = new TcpClient(ServerIp, PortNo);
            var ns = client.GetStream();
            var resMessage = string.Empty;

            while (resMessage != "exit")
            {
                Console.Write(":>");
                var message = Console.ReadLine();
                var sendData = Encoding.ASCII.GetBytes(message);
                ns.Write(sendData, 0, sendData.Length);
                Console.WriteLine("Server : " + message );

                var readData = new byte[client.ReceiveBufferSize];
                var dataRead = ns.Read(readData, 0, client.ReceiveBufferSize);
                Console.WriteLine("Client : " + Encoding.ASCII.GetString(readData, 0, dataRead));
            }

            Console.ReadLine();
            client.Close();
        }
    }
}

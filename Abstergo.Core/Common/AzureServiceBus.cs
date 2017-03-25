using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.ServiceBus.Messaging;
using Abstergo.Entities.Shared;
using Abstergo.Entities.Enums;

namespace Abstergo.Core.Common
{
    class AzureServiceBus
    {
        private const string _connectionString = @"Endpoint=sb://pozitiftest.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=YkPF+AMquMByODpRawY+M5HYu7gDm0qwiVJdlvJHvgM=";
        private const string _queueName = "pozitiftestqueue1";
        private const string _issuerName = "RootManageSharedAccessKey";
        private const string _issuerSecret = @"H/dPOCilXY5Dxk1FMCf1RgHLpGJAToJBU0uye4eEnuE";

        [TestMethod("Azure Servicebus Que baglanarak mesaj gonderir")]
        public void SendQueueMessage(string message = "Hi Guys")
        {
            Stopwatch sw = new Stopwatch();
            QueueClient _queueClient = QueueClient.CreateFromConnectionString(_connectionString, _queueName);

            sw.Start();
            _queueClient.Send(new BrokeredMessage(new AzureMessage
            {
                Id = 1,
                Body = "Deneme"
            }));
            sw.Stop();

            LogMan lm = new LogMan();
            lm.AzureLogToFile(1, sw.Elapsed);
        }

        [TestMethod("Azure Servicebus Que baglanarak mesaj ceker")]
        public void GetQueueMessage()
        {
            int messageCount = 0;

            LogMan lm = new LogMan();
            Stopwatch sw = new Stopwatch();
            QueueClient _queueClient = QueueClient.CreateFromConnectionString(_connectionString, _queueName);

            sw.Start();
            //
            _queueClient.OnMessage(message =>
            {
                Console.WriteLine(String.Format("Message body: {0}", message.GetBody<AzureMessage>().Id));
                messageCount++;
            });
            //
            sw.Stop();
            lm.AzureLogToFile(messageCount, sw.Elapsed);
        }

        [TestMethod("Azure Servicebus 50 bin mesaj gonderir")]
        public void AzureLoadTestSend()
        {
            var status = LogStatus.Stop;
            int count = 0;

            Stopwatch sw = new Stopwatch();
            LogMan lm = new LogMan();
            QueueClient _queueClient = QueueClient.CreateFromConnectionString(_connectionString, _queueName);

            lm.WriteAzureLogStatus(LogStatus.Start);
            sw.Start();
            //
            try
            {
                for (int a = 1; a <= 50000; a++)
                {
                    _queueClient.Send(new BrokeredMessage(new AzureMessage
                    {
                        Id = a,
                        Body = string.Format("{0} numarali mesaj.", a)
                    }));

                    Console.WriteLine(string.Format("{0} id numarali mesaj gonderildi. ", a));
                    lm.AzureLoadTestLog(a);
                    count = a;
                }
            }
            catch (Exception e)
            {
                lm.AzureLogException(e.InnerException.Message);
                status = LogStatus.Abondoned;
            }
            //
            sw.Stop();

            lm.AzureLogToFile(count, sw.Elapsed);
            lm.WriteAzureLogStatus(status);
        }
    }
}

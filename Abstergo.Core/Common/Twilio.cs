using Abstergo.Entities.Shared;
using DMessage;
using DMessage.EuroMsgAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace Abstergo.Core.Common
{
    class Twilio
    {
        private const string apiUsername = "AC30e05d81b35b7beeed25b14a83fc7c7c";
        private const string apiPassword = "528078bc26fb5570786412bbde85196e";

        [TestMethod("EuroMessage uzerinden sms atma.")]
        public void SendSms()
        {
            var twilio = new TwilioRestClient(apiUsername, apiPassword);

            var message = twilio.SendMessage(
          "+12345678901", // From (Replace with your Twilio number)
          "+5309324161", // To (Replace with your phone number)
          "Hello from C#"
          );

            Console.WriteLine(message.Sid);
            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }
    }
}

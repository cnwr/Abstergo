using Abstergo.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Core
{
    class LogMan
    {
        private readonly static string _logFilePath = ConfigurationManager.AppSettings["LogFilePath"];
        private readonly static string _azureLogFilePath = ConfigurationManager.AppSettings["AzureLogFilePath"];
        private readonly static string _fileName = FileName;
        private readonly static string _loadTestFileName = "LoadTest.txt";

        private static string FileName
        {
            get
            {
                return GenerateName() + ".txt";
            }
        }

        private static string GenerateName()
        {
            var now = DateTime.UtcNow;
            return string.Format("{0}{1}{2}", now.Year, now.Month.ToString().PadLeft(2, '0'), now.Day.ToString().PadLeft(2, '0'));
        }

        public void AzureLogToFile(int messageCount, TimeSpan processTime)
        {
            string logText = string.Format("{0} --> MessageCount: {1} ProcessTime: {2}", DateTime.Now.ToShortTimeString(), messageCount, processTime) + Environment.NewLine;
            File.AppendAllText(_azureLogFilePath + _fileName, logText);
        }

        public void AzureLoadTestLog(int id)
        {
            string logText = string.Format("{0} --> MessageId: {1} sent!!", DateTime.Now.ToShortTimeString(), id) + Environment.NewLine;
            File.AppendAllText(_azureLogFilePath + _loadTestFileName, logText);
        }

        public void WriteAzureLogStatus(LogStatus status)
        {
            string logText = string.Empty;
            switch (status)
            {
                case LogStatus.Start:
                    logText = string.Format("{0} --> AzureLoadTestStart!!", DateTime.Now.ToShortTimeString());
                    break;
                case LogStatus.Stop:
                    logText = string.Format("{0} --> AzureLoadTestEnd!!", DateTime.Now.ToShortTimeString());
                    break;
                case LogStatus.Abondoned:
                    logText = string.Format("{0} --> AzureLoadTestAbondoned!!", DateTime.Now.ToShortTimeString());
                    break;
            }
            File.AppendAllText(_azureLogFilePath + _loadTestFileName, logText + Environment.NewLine);
        }

        public void AzureLogException(string ex)
        {
            var logText = string.Format("{0} -->FATAL:{1}", DateTime.Now.ToShortTimeString(), ex);
            File.AppendAllText(_azureLogFilePath + _fileName, logText + Environment.NewLine);
        }
    }
}

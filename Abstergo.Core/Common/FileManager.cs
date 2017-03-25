using Abstergo.Entities.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Core.Common
{
    class FileManager
    {
        [TestMethod("Henuz yazilmadi")]
        public void DownloadPdf()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("" + "test.zip");
                request.Credentials = new NetworkCredential("", "");
                request.UseBinary = true;
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                FileStream writer = new FileStream("test.zip", FileMode.Create);

                long length = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[2048];

                readCount = responseStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    writer.Write(buffer, 0, readCount);
                    readCount = responseStream.Read(buffer, 0, bufferSize);
                }

                responseStream.Close();
                response.Close();
                writer.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}

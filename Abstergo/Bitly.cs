using BitlyDotNET.Implementations;
using BitlyDotNET.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Abstergo
{
    class Bitly
    {
        const string password = "R_b2332506d9fe495ca8999cbd6a58047e";
        const string userName = "o_2get038h6b";
        const string urlToShorten = "http://google.com";

        public static string statusCode = string.Empty;
        public static string statusText = string.Empty;
        public static string shortUrl = string.Empty;
        public static string longUrl = string.Empty;
        public static void BitlyFromWebRequest() {

            XmlDocument xmlDoc = new XmlDocument();                 

            WebRequest request = WebRequest.Create("http://api.bitly.com/v3/shorten");

            byte[] data = Encoding.UTF8.GetBytes(string.Format("login={0}&apiKey={1}&longUrl={2}&format={3}",
             userName,                            
             password,                             
             HttpUtility.UrlEncode(urlToShorten),         
             "xml"));                                    

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (Stream ds = request.GetRequestStream())
            {
                ds.Write(data, 0, data.Length);
            }
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    xmlDoc.LoadXml(sr.ReadToEnd());
                }
            }

            statusCode = xmlDoc.GetElementsByTagName("status_code")[0].InnerText;
            statusText = xmlDoc.GetElementsByTagName("status_txt")[0].InnerText;
            shortUrl = xmlDoc.GetElementsByTagName("url")[0].InnerText;
            longUrl = xmlDoc.GetElementsByTagName("long_url")[0].InnerText;

            Console.WriteLine(statusCode);
            Console.WriteLine(statusText);
            Console.WriteLine(shortUrl);
            Console.WriteLine(longUrl);
            Console.ReadKey();
        }

        public static void BitylFromApi() {
            IBitlyService s = new BitlyService(userName,password);
            if (s.Shorten(urlToShorten, out shortUrl) == StatusCode.OK) {
                Console.WriteLine(shortUrl);
                Console.ReadKey();
            }
        }
    }
}

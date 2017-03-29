using Abstergo.Entities.Shared;
using BitlyDotNET.Implementations;
using BitlyDotNET.Interfaces;
using RestSharp.Extensions.MonoHttp;
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



namespace Abstergo.Core.Common
{
    class Bitly
    {   
        private const string password = "**";
        private const string userName = "**";
        private const string token = "***";
        private const string urlToShorten = "http://google.com";

        private static string statusCode = string.Empty;
        private static string statusText = string.Empty;
        private static string shortUrl = string.Empty;
        private static string longUrl = string.Empty;

        [TestMethod("Web Request atarak shorten url doner.")]
        public void BitlyFromWebRequest() {

            XmlDocument xmlDoc = new XmlDocument();                 

            var request = WebRequest.Create("https://api-ssl.bitly.com/v3/shorten");

            var data = Encoding.UTF8.GetBytes(string.Format("access_token={0}&longUrl={1}&format={2}",
             token,
             System.Web.HttpUtility.UrlEncode(urlToShorten),         
             "xml"));                                    

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var ds = request.GetRequestStream())
            {
                ds.Write(data, 0, data.Length);
            }

            using (var response = request.GetResponse())
            {
                using (var sr = new StreamReader(response.GetResponseStream()))
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

        [TestMethod("Api uzerinden shorten url doner")]
        public string BitylFromApi(string url) {
            IBitlyService s = new BitlyService(userName,password);
           
            if (s.Shorten(url, out shortUrl) == StatusCode.OK) {
                Console.WriteLine(shortUrl);
                Console.ReadKey();
            }

            return shortUrl;
        }
    }
}

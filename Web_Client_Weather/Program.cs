using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Web_Client_Weather
{
    class Program
    {
        static string Find_text_between(string zdroj,string text)
        {
            int first = zdroj.IndexOf(text) + text.Length;
            int last = zdroj.LastIndexOf(text);
            string str2 = zdroj.Substring(first, last - first);
            return str2;
        }

        static string Find_text(string zdroj, string text, int length, int offset)
        {
            int index = zdroj.IndexOf(text) + text.Length;
            string str2 = zdroj.Substring(index+offset, length);
            return str2;
        }



        static void Main(string[] args)
        {

            String str = String.Empty;

            try
            {
                using (WebClient clnt = new WebClient())
                str = clnt.DownloadString("https://api.openweathermap.org/data/2.5/forecast?q=Prague,cz&mode=xml&APPID=bf2be3f9153c1d423a8a290538e5a366");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (!String.IsNullOrEmpty(str))
            {



                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(str);

                

                foreach (XmlNode node in xdoc.SelectNodes("//forecast/time"))   // vsechny uzly kdekoliv
                {
                    Console.Write("{0} ", node.Attributes["from"].Value);

                    XmlNode n = node.SelectSingleNode("./clouds");

                    Console.WriteLine(" {0} {1}{2}", n.Attributes["value"].Value, n.Attributes["all"].Value, n.Attributes["unit"].Value);
                }
            }

            Console.ReadKey();
        }
    }
}

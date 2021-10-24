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
        static string Find_text_between(string zdroj, string text)
        {
            int first = zdroj.IndexOf(text) + text.Length;
            int last = zdroj.LastIndexOf(text);
            string str2 = zdroj.Substring(first, last - first);
            return str2;
        }

        static string Find_text(string zdroj, string text, int length, int offset)
        {
            int index = zdroj.IndexOf(text) + text.Length;
            string str2 = zdroj.Substring(index + offset, length);
            return str2;
        }



        static void Main(string[] args)
        {

            String str = String.Empty;

            try
            {
                using (WebClient clnt = new WebClient())
                    str = clnt.DownloadString("http://svatky.centrum.cz/svatky/jmenne-svatky/");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (!String.IsNullOrEmpty(str))
            {

                str = Find_text(str, "holiday", 100, 61);

                str = str.Substring(0, str.IndexOf("\""));

                Console.WriteLine("Dnes má svátek: {0}", str);

            }

            Console.ReadKey();

        }
    }
}

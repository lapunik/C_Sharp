using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using AForge;

namespace Web_Client_Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            

            String str = String.Empty;

            try
            {
                using (WebClient clnt = new WebClient())
                {

                    clnt.Encoding = Encoding.UTF8;

                    str = clnt.DownloadString("https://www.cnb.cz/cs/financni_trhy/devizovy_trh/kurzy_devizoveho_trhu/denni_kurz.xml");

                }
            }  
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            if (!String.IsNullOrEmpty(str))
            {

                XmlDocument xdoc = new XmlDocument();

                xdoc.LoadXml(str);

                foreach (XmlNode node in xdoc.SelectNodes("//tabulka/radek"))   // vsechny uzly kdekoliv
                {

                    Console.Write("{0}", node.Attributes["kod"].Value);

                    Console.Write("{0,12:F3}\t", (double.Parse(node.Attributes["kurz"].Value)) / (double.Parse(node.Attributes["mnozstvi"].Value)));

                    Console.WriteLine("[{0} => {1}]", node.Attributes["zeme"].Value, node.Attributes["mena"].Value);

                }
            }
        
            Console.ReadKey();
        }
    }
}

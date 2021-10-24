using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KlientWS_kurzovni_listek
{
    class Program
    {
        static void Main(string[] args)
        {

            string s = String.Empty;

            using (Gama_Data.ExchangeRates ws = new Gama_Data.ExchangeRates())
            {

                s = ws.GetCurrentExchangeRatesXML("BS");

            }

            XmlDocument xdoc = new XmlDocument();

            xdoc.LoadXml(s);

            int i = 0;

            foreach (XmlNode node in xdoc.SelectNodes("//exchangeRate")) // (dvě lomítka zajistí že hledám kdekoliv) nodes umí najít všechny uzly daného názvu, nehledi na vnorenost, nejade prostě všechny 
            {
                i++;

                Console.WriteLine("{0}: {1} {2}", i, node.SelectSingleNode("./currencyLabel").InnerText, node.SelectSingleNode("./rateLow").InnerText); // (./ = v dane uzlu)
            }

            //WebClient webClient = new WebClient();
            //webClient.DownloadString("https://www.livesport.cz/");
            // třída: WebClint clt = new bla bla 
            // (.DownloadString("URL nějaký stránky"))
            // open weather
        }
    }
}

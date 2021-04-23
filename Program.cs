using IPNotification.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IPNotification
{
    class Program
    {
        static void Main(string[] args)
        {
            OperacjeXML opxml = new OperacjeXML();
            bool flaga = true;
            if (!opxml.Czy_istnieje_plik_xml(OperacjeXML.PlikiXML.Config))
            {
                opxml.Zapisz_szablon(OperacjeXML.PlikiXML.Config);
                flaga = false;
            }
            if(!opxml.Czy_istnieje_plik_xml(OperacjeXML.PlikiXML.Temp)) opxml.Zapisz_szablon(OperacjeXML.PlikiXML.Temp);
            Temp tp = (Temp)opxml.Pobierz_dane(OperacjeXML.PlikiXML.Temp);
            string myIP;
            try
            {
                myIP = new WebClient().DownloadString("https://api.ipify.org");
            }
            catch (Exception)
            {
                myIP = "";
            }
            if (myIP != tp.AktualneIP)
            {
                tp.AktualneIP = myIP;
                opxml.Zapisz_dane(tp, OperacjeXML.PlikiXML.Temp);
                if (flaga)
                {
                    Config conf = (Config)opxml.Pobierz_dane(OperacjeXML.PlikiXML.Config);
                    Webhook.Webhook.Wyslij_do_webhooka(conf.Webhook, "Nowe IP serwera:\n```"+myIP+"```");
                }
            }
        }
    }
}

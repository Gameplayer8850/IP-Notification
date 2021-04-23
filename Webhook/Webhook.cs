using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IPNotification.Webhook
{
    public class Webhook
    {
        public static void Wyslij_do_webhooka(string url, string wiadomosc)
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    web.UploadValues(url, new NameValueCollection() { { "content", wiadomosc } });
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Nie udało się wysłać wiadomości");
            }
        }
    }
}

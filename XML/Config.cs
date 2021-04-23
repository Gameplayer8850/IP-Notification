using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPNotification.XML
{
    public class Config : IXML
    {
        public string Webhook { get; set; }
        public void StworzSzablon()
        {
            Webhook = "[LINK DO WEBHOOKA]";
        }
    }
}

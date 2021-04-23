using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPNotification.XML
{
    public class Temp : IXML
    {
        public string AktualneIP { get; set; }
        public void StworzSzablon()
        {
            AktualneIP = "";
        }
    }
}

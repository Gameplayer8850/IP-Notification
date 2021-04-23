using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPNotification.XML
{
    public class OperacjeXML
    {
        public List<Type> modeleXml = new List<Type>() { typeof(Config), typeof(Temp) };
        public List<string> nazwyXml = new List<string>() { "Config.xml", "Temp.xml"};
        public string lokalizacja_danych = AppDomain.CurrentDomain.BaseDirectory;

        public enum PlikiXML
        {
            Config, Temp
        }

        public OperacjeXML(string path = null)
        {
            if(path!=null) lokalizacja_danych = path;
        }

        public bool Czy_istnieje_plik_xml(PlikiXML rodzaj)
        {
            Directory.CreateDirectory(lokalizacja_danych);
            return File.Exists(Path.Combine(lokalizacja_danych, nazwyXml[(int)rodzaj]));
        }

        public Object Pobierz_dane(PlikiXML rodzaj)
        {
            Type klasa = modeleXml[(int)rodzaj];
            Object obj = null;
            try
            {
                using (var stream = new FileStream(Path.Combine(lokalizacja_danych, nazwyXml[(int)rodzaj]), FileMode.Open))
                {
                    var XML = new System.Xml.Serialization.XmlSerializer(klasa);
                    obj = XML.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
            return obj;
        }
        public void Zapisz_dane(Object obj, PlikiXML rodzaj)
        {
            Type klasa = modeleXml[(int)rodzaj];
            using (var stream = new FileStream(Path.Combine(lokalizacja_danych, nazwyXml[(int)rodzaj]), FileMode.Create))
            {
                var XML = new System.Xml.Serialization.XmlSerializer(klasa);
                XML.Serialize(stream, obj);
            }
        }
        public object Zapisz_szablon(PlikiXML rodzaj)
        {
            object obj = Activator.CreateInstance(modeleXml[(int)rodzaj]);
            ((IXML)obj).StworzSzablon();
            Zapisz_dane(obj, rodzaj);
            return obj;
        }
    }
}

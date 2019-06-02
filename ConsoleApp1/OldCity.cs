using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    [Serializable]
    public class OldCity
    {
        [System.Xml.Serialization.XmlElementAttribute("dogovor")]
        public string dogovor { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("date")]
        public string date { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("summa")]
        public decimal summa { get; set; }
    }
}

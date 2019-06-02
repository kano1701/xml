using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    [Serializable]
    class ElectricGear
    {
        [XmlArray("c")]
        [XmlArrayItem("a", IsNullable = false)]
        public List<Options> options { get; set; }

        [XmlArray("s")]
        [XmlArrayItem("c", IsNullable = false)]
        public List<C> c { get; set; }
    }

    public class Options
    {
        public string login { get; set; }
        public string password { get; set; }
        public string account { get; set; }
    }

    [Serializable]
    public class C
    {
        [System.Xml.Serialization.XmlElementAttribute("type")]
        public int typ { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("value")]
        public string val { get; set; }
    }
}

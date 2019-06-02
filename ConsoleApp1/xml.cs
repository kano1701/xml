using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    [Serializable]
    public class xml
    {
        [System.Xml.Serialization.XmlElementAttribute("provider")]
        public int provider { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("account")]
        public string account { get; set; }

        [XmlArray("counters")]
        [XmlArrayItem("counter", IsNullable = false)]
        public List<Counter> counters { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("pay_summ")]
        public decimal pay_summ { get; set; }
    }

    [Serializable]
    public class Counter
    {
        [System.Xml.Serialization.XmlElementAttribute("type")]
        public int type { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("value")]
        public string value { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    [DataContract]
    class Drain
    {
        [DataMember]
        public string jsonrpc { get; set; }

        [DataMember]
        public string method { get; set; }

        [DataMember]
        public string id { get; set; }

        public Params Params { get; set; }
    }

    public class Params
    {
        [DataMember]
        public session session { get; set; }

        [DataMember]
        public data data { get; set; }
    }

    public class session
    {
        [DataMember]
        public string login { get; set; }

        [DataMember]
        public string pass { get; set; }
    }

    public class data
    {
        [DataMember]
        public string account { get; set; }

        [DataMember]
        public List<counters> counters { get; set; }

    }

    public class counters
    {
        [DataMember]
        public int type { get; set; }

        [DataMember]
        public string value { get; set; }
    }
}

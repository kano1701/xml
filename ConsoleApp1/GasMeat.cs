using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    [DataContract]
    class GasMeat
    {
        [DataMember]
        public string login { get; set; }

        [DataMember]
        public string parol { get; set; }

        [DataMember]
        public Data data { get; set; }
    }

    public class Data
    {
        [DataMember]
        public string schet { get; set; }

        [DataMember]
        public string pokazaniya { get; set; }

        [DataMember]
        public decimal summa { get; set; }
    }
}

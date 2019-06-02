using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            xml NewXML = new xml();

            NewXML = MyDeserializerXml(NewXML, "data.xml");

            Console.WriteLine($"provider: {NewXML.provider}");
            Console.WriteLine($"account: {NewXML.account}");
            Console.WriteLine($"counters:");

            foreach (Counter elem in NewXML.counters)
            {
                Console.WriteLine($"type: {elem.type}");
                Console.WriteLine($"value: {elem.value}");
            }

            Console.WriteLine($"pay_summ: {NewXML.pay_summ}");

            switch(NewXML.provider)
            {
                case 1:
                    {
                        var gasMeat = new GasMeat()
                        {
                            login = "1mbank",
                            parol = "123456",
                            data = new Data()
                            {
                                schet = NewXML.account,
                                pokazaniya = NewXML.counters[0].value,
                                summa = NewXML.pay_summ
                            }
                        };
                        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(GasMeat));
                        using (FileStream fs = new FileStream("GasMeat.json", FileMode.OpenOrCreate))
                        {
                            jsonFormatter.WriteObject(fs, gasMeat);
                        }
                        break;
                    }
                case 2:
                    {
                        var Drain = new Drain()
                        {
                            jsonrpc = "2.0",
                            method = "fpay",
                            Params = new Params()
                            {
                                session = new session()
                                {
                                    login = "1mbank",
                                    pass = "3333"
                                },
                                data = new data()
                                {
                                    account = NewXML.account
                                }
                            },
                            id = "32303137-3032-3237-3037-3135343423421"
                        };

                        foreach (Counter elem in NewXML.counters)
                        {
                            var counter = new counters() { type = elem.type, value = elem.value };
                            Console.WriteLine($"counter {counter.type} {counter.value}");
                            Drain.Params.data.counters.Add(counter);
                            //у меня здесь ошибка котороую я не знаю как решить
                        }

                        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Drain));
                        using (FileStream fs = new FileStream("Drain.json", FileMode.OpenOrCreate))
                        {
                            jsonFormatter.WriteObject(fs, Drain);
                        }
                        break;
                    }
                case 3:
                    {
                        OldCity oldCity = new OldCity()
                        {
                            date = "04.2016",
                            dogovor = "СГ-43234",
                            summa = NewXML.pay_summ
                        };

                        XmlSerializer serializer = new XmlSerializer(typeof(OldCity));
                        using (FileStream fs = new FileStream("OldCity.xml", FileMode.OpenOrCreate))
                        {
                            serializer.Serialize(fs, oldCity);
                        }
                        break;
                    }
            }

        }

        //static void MySerializerXml(xml NewXML, string path)
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(xml));
        //    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        //    {
        //        serializer.Serialize(fs, NewXML);
        //    }
        //}

        static xml MyDeserializerXml(xml NewXML, string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(xml));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                NewXML = (xml)deserializer.Deserialize(fs);
            }

            return NewXML;
        }
    }
}

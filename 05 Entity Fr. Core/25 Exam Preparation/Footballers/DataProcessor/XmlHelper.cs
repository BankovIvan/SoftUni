namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    public static class XmlHelper
    {
        public static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRootAttribute);
            
            using StringReader xmlReader = new StringReader(inputXml);
            T importXml = (T)xmlSerializer.Deserialize(xmlReader)!;

            return importXml;
        }

        /*
        public static IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), xmlRootAttribute);

            using StringReader xmlReader = new StringReader(inputXml);
            T[] importXml = (T[])xmlSerializer.Deserialize(xmlReader)!;

            return importXml;
        }
        */

        public static string Serialize<T>(T obj, string rootName)
        {
            StringBuilder ret = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(ret);
            xmlSerializer.Serialize(sw, obj, xmlNamespaces);

            return ret.ToString().Trim();
        }

        /*
        public static string SerializeCollection<T>(T[] obj, string rootName)
        {
            StringBuilder ret = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), xmlRoot);
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(ret);
            xmlSerializer.Serialize(sw, obj, xmlNamespaces);

            return ret.ToString().Trim();
        }
        */

    }
}

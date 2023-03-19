namespace CarDealer.DTOs.Import
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("Customer")]
    public class ImportDTO12Customer
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("birthDate")]
        //public DateTime BirthDate { get; set; }
        public String BirthDate { get; set; } = null!;

        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}

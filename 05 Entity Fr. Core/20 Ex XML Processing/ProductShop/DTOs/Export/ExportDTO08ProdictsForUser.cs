namespace ProductShop.DTOs.Export
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("SoldProducts")]
    public class ExportDTO08ProdictsForUser
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public List<ExportDTO08ProductSoldForUser> ProductsSold { get; set; } = null!;
    }
}

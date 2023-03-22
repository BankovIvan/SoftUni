namespace ProductShop.DTOs.Export
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    public class ExportDTO08UserData
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public List<ExportDTO08UserWithSoldProducts> USERS { get; set; } = null!;
    }
}

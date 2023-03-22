namespace ProductShop.DTOs.Export
{
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ExportDTO06UserWithProducts
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; } = null!;

        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;

        [XmlArray("soldProducts")]
        public List<ExportDTO06ProductForUser> ProductsSold { get; set; } = null!;

    }
}

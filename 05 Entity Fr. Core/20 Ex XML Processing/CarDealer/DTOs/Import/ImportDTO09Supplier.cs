namespace CarDealer.DTOs.Import
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("Supplier")]
    public class ImportDTO09Supplier
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}

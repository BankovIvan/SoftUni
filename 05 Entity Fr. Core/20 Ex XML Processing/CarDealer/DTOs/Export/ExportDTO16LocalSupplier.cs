namespace CarDealer.DTOs.Export
{
    using CarDealer.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("supplier")]
    public class ExportDTO16LocalSupplier
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("parts-count")]
        //public virtual ICollection<Part> Parts { get; set; }
        public int COUNT { get; set; }

    }
}

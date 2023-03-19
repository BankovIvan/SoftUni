namespace CarDealer.DTOs.Import
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("partId")]
    public class ImportDTO11PartCar
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}

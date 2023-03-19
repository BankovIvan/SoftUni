namespace CarDealer.DTOs.Import
{
    using CarDealer.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("Car")]
    public class ImportDTO11Car
    {
        [XmlElement("make")]
        public string Make { get; set; } = null!;

        [XmlElement("model")]
        public string Model { get; set; } = null!;

        [XmlElement("traveledDistance")]
        public long TraveledDistance { get; set; }

        /// <summary>
        /// NAME MUST DIFFER THAN PartsCars !!! ???
        /// </summary>
        [XmlArray("parts")]
        public ImportDTO11PartCar[] PARTS { get; set; } = null!;
    }
}

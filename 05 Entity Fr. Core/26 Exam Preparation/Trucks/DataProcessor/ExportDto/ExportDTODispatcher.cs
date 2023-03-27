namespace Trucks.DataProcessor.ExportDto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using Trucks.Data.Models;

    [XmlType("Despatcher")]
    public class ExportDTODispatcher
    {

        [XmlAttribute("TrucksCount")]
        public int TrucksCount { get; set; }

        [XmlElement("DespatcherName")]
        public string Name { get; set; } = null!;

        [XmlArray("Trucks")]
        public virtual List<ExportDTODispatcherTruck> Trucks { get; set; } = null!;

    }
}

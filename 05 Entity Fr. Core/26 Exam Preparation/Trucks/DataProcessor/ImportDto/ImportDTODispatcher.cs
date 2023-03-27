namespace Trucks.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using Trucks.Data.Models;

    [XmlType("Despatcher")]
    public class ImportDTODispatcher
    {
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [XmlElement("Position")]
        public string? Position { get; set; }

        [XmlArray("Trucks")]
        public ImportDTODispatherTruck[] Trucks { get; set; } = null!;

    }
}

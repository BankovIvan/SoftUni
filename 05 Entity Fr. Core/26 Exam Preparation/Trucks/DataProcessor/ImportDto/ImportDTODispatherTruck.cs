namespace Trucks.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using Trucks.Data.Models.Enums;
    using Trucks.Data.Models;

    [XmlType("Truck")]
    public class ImportDTODispatherTruck
    {
        [XmlElement("RegistrationNumber")]
        public string RegistrationNumber { get; set; } = null!;

        [XmlElement("VinNumber")]
        public string VinNumber { get; set; } = null!;

        [XmlElement("TankCapacity")]
        public int TankCapacity { get; set; }

        [XmlElement("CargoCapacity")]
        public int CargoCapacity { get; set; }

        [XmlElement("CategoryType")]
        public string CategoryType { get; set; } = null!;

        [XmlElement("MakeType")]
        public string MakeType { get; set; } = null!;

    }
}

﻿namespace Trucks.DataProcessor.ExportDto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using Trucks.Data.Models.Enums;

    [XmlType("Truck")]
    public class ExportDTODispatcherTruck
    {
        [XmlElement("RegistrationNumber")]
        public string RegistrationNumber { get; set; } = null!;

        [XmlElement("Make")]
        public string Make { get; set; } = null!;

    }
}

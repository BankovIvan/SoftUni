namespace Artillery.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("Manufacturer")]
    public class ImportDTOManufacturer
    {
        [XmlElement("ManufacturerName")]
        public string ManufacturerName { get; set; } = null!;

        [XmlElement("Founded")]
        public string Founded { get; set; } = null!;

    }
}

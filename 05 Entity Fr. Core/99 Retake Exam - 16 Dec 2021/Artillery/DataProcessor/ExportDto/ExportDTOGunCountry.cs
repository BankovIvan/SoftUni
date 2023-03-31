namespace Artillery.DataProcessor.ExportDto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("Country")]
    public class ExportDTOGunCountry
    {
        [XmlAttribute("Country")]
        public string Country { get; set; } = null!;

        [XmlAttribute("ArmySize")]
        public int ArmySize { get; set; }

    }
}

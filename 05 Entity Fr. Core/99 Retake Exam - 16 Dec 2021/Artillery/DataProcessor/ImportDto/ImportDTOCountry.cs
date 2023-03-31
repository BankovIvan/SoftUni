namespace Artillery.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("Country")]
    public class ImportDTOCountry
    {
        [XmlElement("CountryName")]
        public string CountryName { get; set; } = null!;

        [XmlElement("ArmySize")]
        public int ArmySize { get; set; }

    }
}

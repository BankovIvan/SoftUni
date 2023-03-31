namespace Artillery.DataProcessor.ExportDto
{
    using Artillery.Data.Models.Enums;
    using Artillery.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("Gun")]
    public class ExportDTOGun
    {
        public ExportDTOGun()
        {
            this.Countries = new List<ExportDTOGunCountry>();
        }

        [XmlAttribute("Manufacturer")]
        public string Manufacturer { get; set; } = null!;

        [XmlAttribute("GunType")]
        public string GunType { get; set; } = null!;

        [XmlAttribute("GunWeight")]
        public int GunWeight { get; set; }

        [XmlAttribute("BarrelLength")]
        public double BarrelLength { get; set; }

        [XmlAttribute("Range")]
        public int Range { get; set; }

        [XmlArray("Countries")]
        public List<ExportDTOGunCountry> Countries { get; set; } = null!;
    }
}

namespace Artillery.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("Shell")]
    public class ImportDTOShell
    {
        [XmlElement("ShellWeight")]
        public double ShellWeight { get; set; }

        [XmlElement("Caliber")]
        public string Caliber { get; set; } = null!;

    }
}

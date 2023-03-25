namespace Footballers.DataProcessor.ImportDto
{
    using Footballers.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("Coach")]
    public class ImportDTOCoach
    {
        public ImportDTOCoach()
        {
            this.Footballers = new List<ImportDTOCoachFutballer>();
        }

        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [XmlElement("Nationality")]
        public string Nationality { get; set; } = null!;

        [XmlArray("Footballers")]
        public virtual List<ImportDTOCoachFutballer> Footballers { get; set; } = null!;
    }
}

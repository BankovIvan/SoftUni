namespace Footballers.DataProcessor.ExportDto
{
    using Footballers.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("Coach")]
    public class ExportDTOCoach
    {
        public ExportDTOCoach()
        {
            this.Footballers = new List<ExportDTOCoachFootballer>();
        }

        [XmlAttribute("FootballersCount")]
        public int Count { get; set; }

        [XmlElement("CoachName")]
        public string CoachName { get; set; } = null!;

        [XmlArray("Footballers")]
        public List<ExportDTOCoachFootballer> Footballers { get; set; }

    }
}

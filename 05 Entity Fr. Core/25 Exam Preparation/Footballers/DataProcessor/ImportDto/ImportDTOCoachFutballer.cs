namespace Footballers.DataProcessor.ImportDto
{
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("Footballer")]
    public class ImportDTOCoachFutballer
    {
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [XmlElement("ContractStartDate")]
        public string? ContractStartDate { get; set; }

        [XmlElement("ContractEndDate")]
        public string? ContractEndDate { get; set; }

        [XmlElement("PositionType")]
        public int PositionType { get; set; }

        [XmlElement("BestSkillType")]
        public int BestSkillType { get; set; }


    }
}

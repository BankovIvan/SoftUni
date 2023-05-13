namespace Boardgames.DataProcessor.ImportDto
{
    using Boardgames.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("Boardgame")]
    public class ImportDTOCreatorBoardgame
    {
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [XmlElement("Rating")]
        public double Rating { get; set; }

        [XmlElement("YearPublished")]
        public int YearPublished { get; set; }

        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }

        [XmlElement("Mechanics")]
        public string Mechanics { get; set; } = null!;
    }
}

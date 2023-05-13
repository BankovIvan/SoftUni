namespace Boardgames.DataProcessor.ExportDto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("Creator")]
    public class ExportDTOCreator
    {
        public ExportDTOCreator()
        {   
            this.Boardgames = new List<ExportDTOCreatorBoardgame>();
        }

        [XmlAttribute("BoardgamesCount")]
        public int BoardgamesCount { get; set; }

        [XmlElement("CreatorName")]
        public string CreatorName { get; set; } = null!;

        [XmlArray("Boardgames")]
        public List<ExportDTOCreatorBoardgame> Boardgames { get; set; }

    }
}

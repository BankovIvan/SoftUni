namespace Boardgames.DataProcessor.ImportDto
{
    using Boardgames.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("Creator")]
    public class ImportDTOCreator
    {
        public ImportDTOCreator()
        {
            this.Boardgames = new List<ImportDTOCreatorBoardgame>();
        }

        [XmlElement("FirstName")]
        public string FirstName { get; set; } = null!;

        [XmlElement("LastName")]
        public string LastName { get; set; } = null!;

        [XmlArray("Boardgames")]
        public List<ImportDTOCreatorBoardgame> Boardgames { get; set; }

    }
}

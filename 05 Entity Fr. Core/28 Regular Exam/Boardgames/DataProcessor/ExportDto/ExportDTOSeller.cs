namespace Boardgames.DataProcessor.ExportDto
{
    using Boardgames.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExportDTOSeller
    {

        public ExportDTOSeller()
        {
            this.Boardgames = new List<ExportDTOSellerBoardgame>();
        }

        public string Name { get; set; } = null!;

        public string Website { get; set; } = null!;

        public virtual List<ExportDTOSellerBoardgame> Boardgames { get; set; }

    }
}

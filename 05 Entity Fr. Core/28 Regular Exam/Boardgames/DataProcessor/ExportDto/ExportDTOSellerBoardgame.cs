namespace Boardgames.DataProcessor.ExportDto
{
    using Boardgames.Data.Models.Enums;
    using Boardgames.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExportDTOSellerBoardgame
    {
        public string Name { get; set; } = null!;

        public double Rating { get; set; }

        public string Mechanics { get; set; } = null!;

        public string Category { get; set; } = null!;

    }
}

namespace Boardgames.DataProcessor.ImportDto
{
    using Boardgames.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ImportDTOSeller
    {
        public ImportDTOSeller()
        {
            this.Boardgames = new HashSet<int>();
        }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string Website { get; set; } = null!;

        public HashSet<int> Boardgames { get; set; }

    }
}

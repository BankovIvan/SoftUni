namespace Footballers.DataProcessor.ImportDto
{
    using Footballers.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ImportDTOTeam
    {
        public ImportDTOTeam()
        {
            this.Footballers = new HashSet<int>();
        }

        public string Name { get; set; } = null!;

        public string Nationality { get; set; } = null!;

        public int Trophies { get; set; }

        public HashSet<int> Footballers { get; set; }

    }
}

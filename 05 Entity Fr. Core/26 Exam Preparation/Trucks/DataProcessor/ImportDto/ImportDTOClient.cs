namespace Trucks.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Trucks.Data.Models;

    public class ImportDTOClient
    {

        public string Name { get; set; } = null!;

        public string Nationality { get; set; } = null!;

        public string Type { get; set; } = null!;

        public HashSet<int> Trucks { get; set; } = null!;

    }
}

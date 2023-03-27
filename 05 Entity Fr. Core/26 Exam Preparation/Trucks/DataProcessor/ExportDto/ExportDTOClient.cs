namespace Trucks.DataProcessor.ExportDto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using Trucks.Data.Models;

    public class ExportDTOClient
    {
        public ExportDTOClient()
        {
            this.Trucks = new List<ExportDTOClientTruck>();
        }

        public string Name { get; set; } = null!;

        public virtual ICollection<ExportDTOClientTruck> Trucks { get; set; }

    }
}

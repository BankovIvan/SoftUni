namespace Trucks.DataProcessor.ExportDto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Trucks.Data.Models.Enums;
    using Trucks.Data.Models;

    public class ExportDTOClientTruck
    {
        public string TruckRegistrationNumber { get; set; } = null!;

        public string VinNumber { get; set; } = null!;

        public int TankCapacity { get; set; }

        public int CargoCapacity { get; set; }

        public string CategoryType { get; set; } = null!;

        public string MakeType { get; set; } = null!;

    }
}

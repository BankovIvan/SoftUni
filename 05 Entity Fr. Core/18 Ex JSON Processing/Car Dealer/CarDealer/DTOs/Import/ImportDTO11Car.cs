namespace CarDealer.DTOs.Import
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class ImportDTO11Car
    {

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public long TraveledDistance { get; set; }

        //public ICollection<ImportDTO11PartCar> PartsCars { get; set; } = null!; // new HashSet<ImportDTO11PartCar>();

        public int[] PartsId { get; set; } = null!;

    }
}

namespace CarDealer.DTOs.Export
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    public class ExportDTO18SalePrices
    {

        public string Name { get; set; } = null!;

        public int BoughtCars { get; set; }

        public decimal[] CarPrices { get; set; } = null!;

    }
}
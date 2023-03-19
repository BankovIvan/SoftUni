namespace CarDealer.DTOs.Export
{
    using CarDealer.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("sale")]
    public class ExportDTO19SaleAndDiscount
    {
        [XmlElement("car")]
        public ExportDTO19CarData CAR { get; set; } = null!; 

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; } = null!;

        [XmlElement("price")]
        public decimal FullPrice { get; set; }

        [XmlElement("price-with-discount")]
        public decimal DiscountPrice { get; set; }

    }
}

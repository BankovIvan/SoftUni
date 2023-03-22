namespace ProductShop.DTOs.Import
{
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    [XmlType("CategoryProduct")]
    public class ImportDTO04CategoryProduct
    {
        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }

        [XmlElement("ProductId")]
        public int ProductId { get; set; }

    }
}

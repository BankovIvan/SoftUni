namespace ProductShop.DTOs.Export
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExportDTO07UsersWithProductsData
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("products")]
        public ExportDTO07ProductForUserWithSoldProducts[] Products { get; set; } = null!;

    }
}

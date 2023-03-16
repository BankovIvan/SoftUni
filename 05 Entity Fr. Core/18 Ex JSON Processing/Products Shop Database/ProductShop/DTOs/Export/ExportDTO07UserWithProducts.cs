namespace ProductShop.DTOs.Export
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExportDTO07UserWithProducts
    {
        [JsonProperty("lastName")]
        public string LastName { get; set; } = null!;

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("soldProducts")]
        public ExportDTO07UsersWithProductsData SoldProducts { get; set; } = null!;

    }
}

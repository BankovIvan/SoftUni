namespace ProductShop.DTOs.Import
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ImportDTOCategory
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}

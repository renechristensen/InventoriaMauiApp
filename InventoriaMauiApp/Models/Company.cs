using Newtonsoft.Json;
using System;

namespace InventoriaMauiApp.Models
{
    public class Company
    {
        [JsonProperty("CompanyID")]
        public int CompanyID { get; set; }

        [JsonProperty("Name")]
        public string? Name { get; set; }

        [JsonProperty("Description")]
        public string? Description { get; set; }
    }
}
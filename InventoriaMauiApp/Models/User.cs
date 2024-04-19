using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Models
{
    public class User
    {
        [JsonProperty("UserID")]
        public int UserID { get; set; }

        [JsonProperty("Displayname")]
        public string? Displayname { get; set; }

        [JsonProperty("StudieEmail")]
        public string? StudieEmail { get; set; }

        [JsonProperty("CreationDate")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("LastLoginDate")]
        public DateTime LastLoginDate { get; set; }

        [JsonProperty("CompanyID")]
        public int CompanyID { get; set; }

        [JsonProperty("CompanyName")]
        public string? CompanyName { get; set; }

        [JsonProperty("Roles")]
        public List<string> Roles { get; set; } = new List<string>();
    }
}

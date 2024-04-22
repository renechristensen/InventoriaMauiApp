using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace InventoriaMauiApp.Models
{
    public class UpdateEquipmentDTO
    {
        [JsonProperty("Name")]
        [StringLength(255)]
        public string Name { get; set; }

        [JsonProperty("Model")]
        [StringLength(255)]
        public string Model { get; set; }

        [JsonProperty("Type")]
        [StringLength(255)]
        public string Type { get; set; }
    }
}

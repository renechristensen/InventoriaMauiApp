using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoriaMauiApp.Models
{
    public class CreateEquipmentDTO
    {
        [JsonProperty("Name")]
        [Required, StringLength(255)]
        public string Name { get; set; }

        [JsonProperty("Model")]
        [Required, StringLength(255)]
        public string Model { get; set; }

        [JsonProperty("Type")]
        [Required, StringLength(255)]
        public string Type { get; set; }

        [JsonProperty("RackUnitIDs")]
        public List<int> RackUnitIDs { get; set; }
    }
}

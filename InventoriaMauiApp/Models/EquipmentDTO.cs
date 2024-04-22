using Newtonsoft.Json;
using System.Collections.Generic;

namespace InventoriaMauiApp.Models
{
    public class EquipmentDTO
    {
        [JsonProperty("EquipmentID")]
        public int EquipmentID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Model")]
        public string Model { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("RackUnitIDs")]
        public List<int> RackUnitIDs { get; set; }
    }
}

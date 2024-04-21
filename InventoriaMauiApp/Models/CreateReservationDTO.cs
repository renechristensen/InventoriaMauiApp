using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace InventoriaMauiApp.Models
{
    public class CreateReservationDTO
    {
        [JsonProperty("UserID")]
        public int UserID { get; set; }

        [JsonProperty("StartDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("EndDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty("Background")]
        public string Background { get; set; }

        [JsonProperty("RackUnitIDs")]
        public List<int> RackUnitIDs { get; set; }
    }
}

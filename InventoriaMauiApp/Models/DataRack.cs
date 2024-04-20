using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace InventoriaMauiApp.Models
{
    public class DataRack
    {
        [JsonProperty("DataRackID")]
        public int DataRackID { get; set; }

        [JsonProperty("DatarackName")]
        public string? DatarackName { get; set; }

        [JsonProperty("ServerRoomName")]
        public string? ServerRoomName { get; set; }

        [JsonProperty("RackStartupDate")]
        public DateTime RackStartupDate { get; set; }

        [JsonProperty("RackStatus")]
        public string? RackStatus { get; set; }

        [JsonProperty("TotalUnits")]
        public int TotalUnits { get; set; }

        [JsonProperty("AvailableUnits")]
        public int AvailableUnits { get; set; }

        [JsonProperty("DataCenterName")]
        public string? DataCenterName { get; set; }

        [JsonProperty("CompanyName")]
        public string? CompanyName { get; set; }

        [JsonProperty("RackPlacement")]
        public string? RackPlacement { get; set; }

        [JsonProperty("Roles")]
        public List<string> Roles { get; set; } = new List<string>();
    }
}

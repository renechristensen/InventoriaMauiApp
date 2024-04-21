using Newtonsoft.Json;
using System;

namespace InventoriaMauiApp.Models
{
    public class RackUnitFlatDTO
    {
        [JsonProperty("RackUnitID")]
        public int RackUnitID { get; set; }

        [JsonProperty("UnitNumber")]
        public int UnitNumber { get; set; }

        [JsonProperty("StartDate")]
        public string? StartDate { get; set; }

        [JsonProperty("EndDate")]
        public string? EndDate { get; set; }

        [JsonProperty("ReservationBackground")]
        public string? ReservationBackground { get; set; }

        [JsonProperty("DisplayName")]
        public string? DisplayName { get; set; }

        [JsonProperty("StudieEmail")]
        public string? StudieEmail { get; set; }

        [JsonProperty("EquipmentName")]
        public string? EquipmentName { get; set; }

        [JsonProperty("EquipmentModel")]
        public string? EquipmentModel { get; set; }

        [JsonProperty("EquipmentType")]
        public string? EquipmentType { get; set; }

        // local variable
        public bool IsSelected { get; set; }
    }
}

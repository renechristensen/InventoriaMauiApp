﻿
namespace InventoriaMauiApp.DTOs
{
    public class ReservationDTO
    {
        public int ReservationID { get; set; }
        public int UserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Background { get; set; }
    }
}
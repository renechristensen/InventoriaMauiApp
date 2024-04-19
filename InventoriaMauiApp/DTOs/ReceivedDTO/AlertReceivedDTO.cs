using System;

namespace InventoriaMauiApp.DTOs
{
    public class AlertReceivedDTO
    {
        public int AlertID { get; set; }
        public int AlertTypeID { get; set; }
        public bool ThresholdExceeded { get; set; }
        public int EnvironmentalReadingID { get; set; }
        public DateTime AlertTimestamp { get; set; }
        public bool Resolved { get; set; }
    }
}

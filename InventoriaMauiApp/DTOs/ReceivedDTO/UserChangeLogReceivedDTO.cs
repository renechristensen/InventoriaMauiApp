﻿namespace InventoriaMauiApp.DTOs
{
    public class UserChangeLogReceivedDTO
    {
        public int UserChangeLogID { get; set; }
        public int UserID { get; set; }
        public int ChangedByUserID { get; set; }
        public string ChangeType { get; set; }
        public DateTime ChangeTimestamp { get; set; }
        public string ChangeDescription { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace InventoriaMauiApp.DTOs;
public class UserDTO
{
    public int UserID { get; set; }
    public string? Displayname { get; set; }
    public string? StudieEmail { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastLoginDate { get; set; }
    public int CompanyID { get; set; }
    public string? CompanyName { get; set; }
    public List<string> Roles { get; set; } = new List<string>();
}



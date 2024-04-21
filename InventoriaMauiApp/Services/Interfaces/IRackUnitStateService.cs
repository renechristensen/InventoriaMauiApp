using InventoriaMauiApp.Models;
using System;

namespace InventoriaMauiApp.Services
{
    public interface IRackUnitStateService
    {
        RackUnitFlatDTO CurrentRackUnit { get; set; }
        HashSet<int> SelectedRackUnitIds { get; set; }
        event Action OnRackUnitChanged;
    }
}

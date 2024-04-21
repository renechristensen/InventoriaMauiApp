using InventoriaMauiApp.Models;
using System;

namespace InventoriaMauiApp.Services
{
    public interface IRackUnitStateService
    {
        RackUnitFlatDTO CurrentRackUnit { get; set; }
        event Action OnRackUnitChanged;
    }
}

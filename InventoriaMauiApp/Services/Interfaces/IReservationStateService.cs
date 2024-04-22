using InventoriaMauiApp.Models;
using System;

namespace InventoriaMauiApp.Services
{
    public interface IReservationStateService
    {
        ReservationDTO CurrentReservationDTO { get; set; }
        HashSet<int> SelectedRackUnitIds { get; set; }
        event Action OnReservationChanged;
    }
}

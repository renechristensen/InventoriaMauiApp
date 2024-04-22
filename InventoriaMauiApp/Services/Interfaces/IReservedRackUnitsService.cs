using System.Collections.Generic;
using System.Threading.Tasks;
using InventoriaMauiApp.Models;

namespace InventoriaMauiApp.Services
{
    public interface IReservedRackUnitsService
    {
        Task<List<RackUnitFlatDTO>> GetReservedRackUnitsByReservationIdAsync(int reservationId);
    }
}

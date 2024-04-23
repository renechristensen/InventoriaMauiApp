using System.Collections.Generic;
using System.Threading.Tasks;
using InventoriaMauiApp.Models;

namespace InventoriaMauiApp.Services
{
    public interface IReservationService
    {
        public Task<ReservationDTO> GetReservationById(int reservationId);
        public Task<ReservationDTO> CreateReservation(CreateReservationDTO reservation);
        public Task<List<ReservationDTO>> GetReservationsByUser(int userId);
        public Task<bool> DeleteReservation(int reservationId);

    }
}


using InventoriaMauiApp.Models;
using System;
using System.Collections.Generic;

namespace InventoriaMauiApp.Services
{
    public class ReservationStateService : IReservationStateService
    {

        private ReservationDTO _currentReservationDTO;
        private HashSet<int> _selectedReserevationIds = new HashSet<int>();

        public ReservationDTO CurrentReservationDTO
        {
            get => _currentReservationDTO;
            set
            {
                if (_currentReservationDTO != value)
                {
                    _currentReservationDTO = value;
                    OnReservationChanged?.Invoke();
                }
            }
        }

        public HashSet<int> SelectedRackUnitIds
        {
            get => _selectedReserevationIds;
            set
            {
                if (_selectedReserevationIds != value)
                {
                    _selectedReserevationIds = value;
                    OnReservationChanged?.Invoke();
                }
            }
        }

        public event Action OnReservationChanged;
    }
}

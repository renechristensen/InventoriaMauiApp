using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoriaMauiApp.Models;
using InventoriaMauiApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoriaMauiApp.ViewModels
{
    public partial class ReservationRackUnitsViewModel : ViewModelBase
    {
        private readonly IReservedRackUnitsService _reservedRackUnitsService;
        private readonly IReservationStateService _reservationStateService;
        private ObservableCollection<RackUnitFlatDTO> _rackUnits = new();
        public ICommand NavigateBackCommand { get; }
        public ICommand InsertEquipmentCommand { get; private set; }
        public ICommand LoadReservedRackUnitsCommand { get; private set; }
        public ObservableCollection<RackUnitFlatDTO> RackUnits
        {
            get => _rackUnits;
            set => Set(ref _rackUnits, value);
        }

        public ReservationRackUnitsViewModel(IReservedRackUnitsService reservedRackUnitsService, IReservationStateService reservationStateService)
        {
            _reservedRackUnitsService = reservedRackUnitsService;
            LoadReservedRackUnitsCommand = new RelayCommand(async () => await LoadReservedRackUnits());
            InsertEquipmentCommand = new RelayCommand(InsertEquipment);
            _reservationStateService = reservationStateService;
            NavigateBackCommand = new RelayCommand(NavigateBack);
        }

        private async Task LoadReservedRackUnits()
        {
            try
            {
                var units = await _reservedRackUnitsService.GetReservedRackUnitsByReservationIdAsync(_reservationStateService.CurrentReservationDTO.ReservationID);
                RackUnits = new ObservableCollection<RackUnitFlatDTO>(units);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Failed to load reserved rack units: " + ex.Message);
                // Handle exceptions or errors appropriately
            }
        }
        private void InsertEquipment()
        {
            // Placeholder for inserting equipment logic
            Console.WriteLine("Insert equipment functionality is not yet implemented.");
        }
        private async void NavigateBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

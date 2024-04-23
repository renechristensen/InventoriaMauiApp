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
        private readonly IRackUnitStateService _rackUnitStateService;
        private ObservableCollection<RackUnitFlatDTO> _rackUnits = new();
        public ICommand NavigateBackCommand { get; }
        public ICommand InsertEquipmentCommand { get; private set; }
        public ICommand LoadReservedRackUnitsCommand { get; private set; }
        public ObservableCollection<RackUnitFlatDTO> RackUnits
        {
            get => _rackUnits;
            set => Set(ref _rackUnits, value);
        }

        public ReservationRackUnitsViewModel(IReservedRackUnitsService reservedRackUnitsService, IReservationStateService reservationStateService, IRackUnitStateService rackUnitStateService)
        {
            _reservedRackUnitsService = reservedRackUnitsService;
            _reservationStateService = reservationStateService;
            _rackUnitStateService = rackUnitStateService;
            LoadReservedRackUnitsCommand = new RelayCommand(async () => await LoadReservedRackUnits());
            InsertEquipmentCommand = new RelayCommand(InsertEquipment);
            NavigateBackCommand = new RelayCommand(NavigateBack);

        }

        private async Task LoadReservedRackUnits()
        {
            try
            {
                _rackUnitStateService.SelectedRackUnitIds.Clear();
                RackUnits.Clear();
                var units = await _reservedRackUnitsService.GetReservedRackUnitsByReservationIdAsync(_reservationStateService.CurrentReservationDTO.ReservationID);
                RackUnits = new ObservableCollection<RackUnitFlatDTO>(units);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Failed to load reserved rack units: " + ex.Message);
                // Handle exceptions or errors appropriately
            }
        }

        public void HandleCheckChanged(RackUnitFlatDTO rackUnit, bool isChecked)
        {
            if (rackUnit == null) return;

            rackUnit.IsSelected = isChecked;

            if (isChecked)
                _reservationStateService.SelectedRackUnitIds.Add(rackUnit.RackUnitID);
            else
                _reservationStateService.SelectedRackUnitIds.Remove(rackUnit.RackUnitID);

            OnPropertyChanged(nameof(RackUnits));
        }

        private void InsertEquipment()
        {
            Console.Write(_reservationStateService.SelectedRackUnitIds);
            // Placeholder for inserting equipment logic
            Shell.Current.GoToAsync("InsertEquipmentPage");

        }
        private async void NavigateBack()
        {
           await Shell.Current.GoToAsync("ReservationDetailsPage");
        }

        [RelayCommand]
        private async Task ViewRackUnitDetails(RackUnitFlatDTO rackUnit)
        {
            if (rackUnit != null)
            {
                _rackUnitStateService.CurrentRackUnit = rackUnit;
                await Shell.Current.GoToAsync($"ReservedRackUnitDetailsPage");
            }
        }
    }
}

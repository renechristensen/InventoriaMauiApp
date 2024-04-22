using System.Collections.ObjectModel;
using System.Threading.Tasks;
using InventoriaMauiApp.Models;
using InventoriaMauiApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic; // Ensure this is added for HashSet
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace InventoriaMauiApp.ViewModels
{
    public partial class DataRackUnitsViewModel : ViewModelBase
    {
        private readonly IRackUnitService _rackUnitService;
        private readonly IDataRackStateService _dataRackStateService;
        private readonly IRackUnitStateService _rackUnitStateService;

        private ObservableCollection<RackUnitFlatDTO> _rackUnits = new();

        private HashSet<int> _selectedRackUnitIds = new();
        public ICommand LoadDataCommand { get; }
        public ICommand LoadRackUnitsCommand { get; set; }
        public ICommand ViewRackUnitDetailsCommand { get; set; }
        public ICommand ToggleReservationCommand { get; }
        public ICommand NavigateBackCommand { get; private set; }
        public ICommand NavigateToReservationCommand { get; private set; }
        public ObservableCollection<RackUnitFlatDTO> RackUnits
        {
            get => _rackUnits;
            set => Set(ref _rackUnits, value);
        }


        public HashSet<int> SelectedRackUnitIds
        {
            get => _selectedRackUnitIds;
            set => Set(ref _selectedRackUnitIds, value);
        }



        public DataRackUnitsViewModel(IRackUnitService rackUnitService, IDataRackStateService dataRackStateService, IRackUnitStateService rackUnitStateService)
        {
            _rackUnitService = rackUnitService;
            _dataRackStateService = dataRackStateService;
            LoadDataCommand = new RelayCommand(Appearing);
            _rackUnitStateService = rackUnitStateService;

            LoadRackUnitsCommand = new Command(async () => await LoadRackUnits());
            ViewRackUnitDetailsCommand = new Command<RackUnitFlatDTO>(async (rackUnit) => await ViewRackUnitDetails(rackUnit));
            ToggleReservationCommand = new Command<int>(ToggleReservation);
            NavigateBackCommand = new Command(async () => await Shell.Current.GoToAsync("DataRackDetailsPage"));
            NavigateToReservationCommand = new Command(async () => await GoToReservation());
        }

        public async Task GoToReservation()
        {

            _rackUnitStateService.SelectedRackUnitIds = _selectedRackUnitIds;
            await Shell.Current.GoToAsync("ReservationPage");
        }
        public async Task LoadRackUnits()
        {
            try
            {
                if (_dataRackStateService.CurrentDataRack != null)
                {
                    var units = await _rackUnitService.GetAllRackUnitsByDataRackIdAsync(_dataRackStateService.CurrentDataRack.DataRackID);
                    RackUnits = new ObservableCollection<RackUnitFlatDTO>(units);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load rack units: " + ex.Message);
            }
        }

        private async Task ViewRackUnitDetails(RackUnitFlatDTO rackUnit)
        {
            if (rackUnit != null)
            {
                _rackUnitStateService.CurrentRackUnit = rackUnit;
                await Shell.Current.GoToAsync($"RackUnitDetailsPage");
            }
        }

        public void HandleCheckChanged(RackUnitFlatDTO rackUnit, bool isChecked)
        {
            if (rackUnit == null) return;

            if (isChecked)
            {
                if (!_selectedRackUnitIds.Contains(rackUnit.RackUnitID))
                {
                    _selectedRackUnitIds.Add(rackUnit.RackUnitID);
                }
            }
            else
            {
                if (_selectedRackUnitIds.Contains(rackUnit.RackUnitID))
                {
                    _selectedRackUnitIds.Remove(rackUnit.RackUnitID);
                }
            }

            // Notify UI about the change if necessary
            OnPropertyChanged(nameof(SelectedRackUnitIds));
        }
        private void ToggleReservation(int rackUnitID)
        {
            if (_selectedRackUnitIds.Contains(rackUnitID))
                _selectedRackUnitIds.Remove(rackUnitID);
            else
                _selectedRackUnitIds.Add(rackUnitID);

            OnPropertyChanged(nameof(SelectedRackUnitIds)); // Notify UI about changes
        }
        [RelayCommand]
        public void Appearing()
        {
            _rackUnitStateService.SelectedRackUnitIds.Clear();
            RackUnits.Clear();
            LoadRackUnits();
        }
    }
}

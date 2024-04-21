using System.Collections.ObjectModel;
using System.Threading.Tasks;
using InventoriaMauiApp.Models;
using InventoriaMauiApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
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
        public ICommand LoadDataCommand { get; }


        public ICommand LoadRackUnitsCommand { get; set; }
        public ICommand ViewRackUnitDetailsCommand { get; set; }
        public ICommand ToggleReservationCommand { get; }

        public DataRackUnitsViewModel(IRackUnitService rackUnitService, IDataRackStateService dataRackStateService, IRackUnitStateService rackUnitStateService)
        {
            _rackUnitService = rackUnitService;
            _dataRackStateService = dataRackStateService;
            LoadDataCommand = new RelayCommand(Appearing);
            _rackUnitStateService = rackUnitStateService;

            LoadRackUnitsCommand = new Command(async () => await LoadRackUnits());
            ViewRackUnitDetailsCommand = new Command<RackUnitFlatDTO>(async (rackUnit) => await ViewRackUnitDetails(rackUnit));
            ToggleReservationCommand = new Command<RackUnitFlatDTO>(ToggleReservation);
        }
        public ObservableCollection<RackUnitFlatDTO> RackUnits
        {
            get => _rackUnits;
            set => Set(ref _rackUnits, value);
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
            if (rackUnit == null) return;

            _rackUnitStateService.CurrentRackUnit = rackUnit;
            await Shell.Current.GoToAsync($"RackUnitDetailsPage");
        }

        private void ToggleReservation(RackUnitFlatDTO rackUnit)
        {
            if (rackUnit == null) return;

            // Implementation of toggle reservation here, assuming updating the UI or the server
        }
        [RelayCommand]
        public void Appearing()
        {
            RackUnits.Clear();
            LoadRackUnits();
        }
    }
}

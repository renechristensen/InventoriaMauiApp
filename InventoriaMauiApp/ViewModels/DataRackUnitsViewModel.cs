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


        public DataRackUnitsViewModel(IRackUnitService rackUnitService, IDataRackStateService dataRackStateService, IRackUnitStateService rackUnitStateService)
        {
            _rackUnitService = rackUnitService;
            _dataRackStateService = dataRackStateService;
            LoadDataCommand = new RelayCommand(Appearing);
            LoadRackUnits();
            _rackUnitStateService = rackUnitStateService;
        }

        public ObservableCollection<RackUnitFlatDTO> RackUnits
        {
            get => _rackUnits;
            set => Set(ref _rackUnits, value);
        }

        [RelayCommand]
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
                // Handle exceptions (e.g., log the error and inform the user)
                Console.WriteLine("Failed to load rack units: " + ex.Message);
            }
        }

        // Called when the page appears
        [RelayCommand]
        public void Appearing()
        {
            RackUnits.Clear();
            LoadRackUnits();
        }
    }
}

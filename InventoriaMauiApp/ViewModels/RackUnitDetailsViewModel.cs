using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using InventoriaMauiApp.Models;
using InventoriaMauiApp.Services;

namespace InventoriaMauiApp.ViewModels
{
    public partial class RackUnitDetailsViewModel : ViewModelBase
    {
        private RackUnitFlatDTO _rackUnit;
        private IRackUnitStateService _rackUnitStateService;
        public ICommand NavigateBackCommand { get; }

        public RackUnitFlatDTO RackUnit
        {
            get => _rackUnit;
            set => Set(ref _rackUnit, value);
        }

        public RackUnitDetailsViewModel(IRackUnitStateService rackUnitStateService)
        {
            NavigateBackCommand = new Command(() => NavigateBackToDataRackOverview());
            _rackUnitStateService = rackUnitStateService;
            _rackUnit = _rackUnitStateService.CurrentRackUnit;
        }

        private void NavigateBackToDataRackOverview()
        {
            Shell.Current.GoToAsync("DataRackUnitsPage");
        }
    }
}

using System.Windows.Input;
using InventoriaMauiApp.Models;
using InventoriaMauiApp.Services;
using System.Threading.Tasks;

namespace InventoriaMauiApp.ViewModels
{
    public class ReservedRackUnitDetailsPageViewModel : ViewModelBase
    {
        private readonly IRackUnitStateService _rackUnitStateService;
        private readonly IEquipmentService _equipmentService;
        private RackUnitFlatDTO _rackUnit;

        public ICommand NavigateBackCommand { get; }
        public ICommand RemoveEquipmentCommand { get; }

        public ReservedRackUnitDetailsPageViewModel(IRackUnitStateService rackUnitStateService, IEquipmentService equipmentService)
        {
            _rackUnitStateService = rackUnitStateService;
            _equipmentService = equipmentService;
            _rackUnit = _rackUnitStateService.CurrentRackUnit;

            NavigateBackCommand = new Command(async () => await NavigateBack());
            RemoveEquipmentCommand = new Command(async () => await RemoveEquipment());
        }

        public RackUnitFlatDTO RackUnit
        {
            get => _rackUnit;
            set => Set(ref _rackUnit, value);
        }

        private async Task NavigateBack()
        {
            await Shell.Current.GoToAsync("ReservedUnitsPage");
        }

        private async Task RemoveEquipment()
        {
            if (_rackUnit != null && _rackUnit.RackUnitID > 0)
            {
                var success = await _equipmentService.DeleteEquipmentByRackUnitId(_rackUnit.RackUnitID);
                if (success)
                {
                    Console.WriteLine("Equipment successfully removed.");
                    await Shell.Current.DisplayAlert("Success", "Equipment removed successfully", "OK");
                    await Shell.Current.GoToAsync("ReservedUnitsPage");
                }
                else
                {
                    Console.WriteLine("Failed to remove equipment.");
                    await Shell.Current.DisplayAlert("Error", "Failed to remove equipment", "OK");
                }
            }
        }
    }
}

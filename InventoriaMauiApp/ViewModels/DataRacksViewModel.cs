using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using InventoriaMauiApp.Models;
using InventoriaMauiApp.Services;
using CommunityToolkit.Mvvm.Input;
using InventoriaMauiApp.View; // Ensure you have installed the CommunityToolkit.Maui NuGet package

namespace InventoriaMauiApp.ViewModels
{
    public partial class DataRacksViewModel : ViewModelBase
    {
        private ObservableCollection<DataRack> _dataRacks = new();
        private readonly IDataRackService _dataRackService;
        private readonly IDataRackStateService _dataRackStateService;
        public DataRacksViewModel(IDataRackService dataRackService, IDataRackStateService dataRackStateService)
        {
            _dataRackService = dataRackService;
            _dataRackStateService = dataRackStateService;
            LoadDataRacks();
        }
        public ObservableCollection<DataRack> DataRacks
        {
            get => _dataRacks;
            set => Set(ref _dataRacks, value);
        }

        public DataRack SelectedDataRack { get; set; }

        [RelayCommand]
        public async Task LoadDataRacks()
        {
            try
            {
                var racks = await _dataRackService.GetAllDataRacksAsync();
                DataRacks = new ObservableCollection<DataRack>(racks);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Unable to load data racks: " + ex.Message, "OK");
            }
        }

        [RelayCommand]
        private async Task ViewDataRackDetails(DataRack dataRack)
        {
            if (dataRack == null) return;
            // Navigate to the details page for the selected data rack
            _dataRackStateService.CurrentDataRack = dataRack;
            await Shell.Current.GoToAsync($"DataRackDetailsPage", true, new Dictionary<string, object> { { "DataRack", dataRack } });
            //await Shell.Current.GoToAsync($"{nameof(DataRackDetailsPage)}", true, new Dictionary<string, object> { { "DataRack", dataRack } });
        }



        [RelayCommand]
        void Appearing()
        {
            LoadDataRacks().ConfigureAwait(false);
        }
    }
}


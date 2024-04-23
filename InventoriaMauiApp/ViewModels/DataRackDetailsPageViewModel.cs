using System;
using System.Collections.Generic;
using InventoriaMauiApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoriaMauiApp.Services;
using System.Windows.Input;

namespace InventoriaMauiApp.ViewModels
{
    public partial class DataRackDetailsPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private DataRack _dataRack;
        private readonly IDataRackStateService _dataRackStateService;

        public ICommand NavigateBackCommand { get; }
        public ICommand OpenRackContentCommand { get; }
        public DataRackDetailsPageViewModel(IDataRackStateService dataRackStateService)
        {
            _dataRackStateService = dataRackStateService;
            DataRack = _dataRackStateService.CurrentDataRack;
            NavigateBackCommand = new Command(async () => await NavigateBack());
            OpenRackContentCommand = new Command(async () => await OpenRackContent());
        }

        private async Task NavigateBack()
        {
            await Shell.Current.GoToAsync("//DataRackOverView");
        }

        private async Task OpenRackContent()
        {
            // Navigate to DataRackUnitsPage without parameters
            await Shell.Current.GoToAsync("DataRackUnitsPage");
        }
    }
}

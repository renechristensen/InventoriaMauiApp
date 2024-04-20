using System;
using System.Collections.Generic;
using InventoriaMauiApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoriaMauiApp.Services;

namespace InventoriaMauiApp.ViewModels
{
    public partial class DataRackDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private DataRack _dataRack;
        private readonly IDataRackStateService _dataRackStateService;


        public DataRackDetailsViewModel(IDataRackStateService dataRackStateService)
        {
            _dataRackStateService = dataRackStateService;
            DataRack = _dataRackStateService.CurrentDataRack;
        }

        // Example Command (if you need to perform actions like saving changes, etc.)
        [RelayCommand]
        private void PerformSomeAction()
        {
            // Implement your logic
        }
    }
}

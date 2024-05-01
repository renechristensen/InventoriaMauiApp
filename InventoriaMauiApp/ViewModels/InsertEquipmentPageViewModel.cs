using InventoriaMauiApp.Models;
using InventoriaMauiApp.Services;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace InventoriaMauiApp.ViewModels
{
    public class InsertEquipmentPageViewModel : ViewModelBase
    {
        private string _name;
        private string _model;
        private string _type;

        private readonly IEquipmentService _equipmentService;
        private readonly IReservationStateService _reservationStateService;

        public ICommand CreateEquipmentCommand { get; }
        public ICommand NavigateBackCommand { get; }

        public InsertEquipmentPageViewModel(IEquipmentService equipmentService, IReservationStateService reservationStateService)
        {
            _equipmentService = equipmentService;
            _reservationStateService = reservationStateService;

            CreateEquipmentCommand = new Command(async () => await CreateEquipment());
            NavigateBackCommand = new Command(async () => await Shell.Current.GoToAsync("ReservedUnitsPage"));
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Model
        {
            get => _model;
            set => Set(ref _model, value);
        }

        public string Type
        {
            get => _type;
            set => Set(ref _type, value);
        }

        private async Task CreateEquipment()
        {
            var createEquipmentDTO = new CreateEquipmentDTO
            {
                Name = Name,
                Model = Model,
                Type = Type,
                RackUnitIDs = new List<int>(_reservationStateService.SelectedRackUnitIds)
            };
            _reservationStateService.SelectedRackUnitIds.Clear();
            try
            {
                var equipment = await _equipmentService.CreateEquipment(createEquipmentDTO);
                await Application.Current.MainPage.DisplayAlert("Success", "Equipment created successfully.", "OK");
                await Shell.Current.GoToAsync("//ReservationOverviewPage");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to create equipment: " + ex.Message, "OK");
            }
        }
    }
}

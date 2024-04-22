using InventoriaMauiApp.Models;
using InventoriaMauiApp.Services;
using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;

namespace InventoriaMauiApp.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now.AddDays(1);
        private string _background;

        private readonly IReservationService _reservationService;
        private readonly IRackUnitStateService _rackUnitStateService;
        private readonly IUserStateService _userStateService;

        public ICommand CreateReservationCommand { get; }
        public ICommand NavigateBackCommand { get; }

        public ReservationViewModel(IReservationService reservationService, IRackUnitStateService rackUnitStateService, IUserStateService userStateService)
        {
            _reservationService = reservationService;
            _rackUnitStateService = rackUnitStateService;

            CreateReservationCommand = new Command(async () => await CreateReservation());

            NavigateBackCommand = new Command(async () => await Shell.Current.GoToAsync("DataRackUnitsPage"));
            _userStateService = userStateService;
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => Set(ref _startDate, value);
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => Set(ref _endDate, value);
        }

        public DateTime MinimumDate => DateTime.Now;
        public DateTime MinimumTomorrowDate => DateTime.Now.AddDays(1);
        public DateTime MaximumDate => DateTime.Now.AddYears(1);

        public string Background
        {
            get => _background;
            set => Set(ref _background, value);
        }

        private async Task CreateReservation()
        {
            var createReservationDTO = new CreateReservationDTO
            {
                UserID = _userStateService.CurrentUser.UserID,
                StartDate = StartDate,
                EndDate = EndDate,
                Background = Background,
                RackUnitIDs = new List<int>(_rackUnitStateService.SelectedRackUnitIds)
            };

            try
            {
                var reservation = await _reservationService.CreateReservation(createReservationDTO);
                await Application.Current.MainPage.DisplayAlert("Success", "Reservation created successfully.", "OK");
                await Shell.Current.GoToAsync("//DataRackOverView");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to create reservation: " + ex.Message, "OK");
            }
        }
    }
}
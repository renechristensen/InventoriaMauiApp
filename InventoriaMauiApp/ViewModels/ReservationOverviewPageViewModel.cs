using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoriaMauiApp.Models;
using InventoriaMauiApp.Services;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoriaMauiApp.ViewModels
{
    public partial class ReservationOverviewPageViewModel : ViewModelBase
    {
        private readonly IReservationService _reservationService;
        private readonly IUserStateService _userStateService;
        private readonly IReservationStateService _reservationStateService;

        private ObservableCollection<ReservationDTO> _reservations;

        public ICommand LoadReservationsCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
        public ICommand OpenReservationDetailsCommand { get; }
        public ReservationOverviewPageViewModel(IReservationService reservationService, IUserStateService userStateService, IReservationStateService reservationStateService)
        {
            LoadReservationsCommand = new RelayCommand(Appearing);
            _reservationService = reservationService;
            _userStateService = userStateService;
            _reservationStateService = reservationStateService;
            GoBackCommand = new Command(async () => await GoBack());
            LoadReservations();
        }

        public ObservableCollection<ReservationDTO> Reservations
        {
            get => _reservations;
            set => Set(ref _reservations, value);
        }

        private async Task LoadReservations()
        {
            try
            {
                var userReservations = await _reservationService.GetReservationsByUser(_userStateService.CurrentUser.UserID);
                Reservations = new ObservableCollection<ReservationDTO>(userReservations);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Unable to load reservations: {ex.Message}", "OK");
            }
        }

        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("ReservationDetailsPage");
        }

        [RelayCommand]
        private async Task OpenDetailsPage(ReservationDTO reservationDTO)
        {
            _reservationStateService.CurrentReservationDTO = reservationDTO;
            await Shell.Current.GoToAsync("ReservationDetailsPage");
        }
        [RelayCommand]
        public void Appearing()
        {
            LoadReservations();
        }
    }
}

using System;
using System.Collections.Generic;
using InventoriaMauiApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoriaMauiApp.Services;
using System.Windows.Input;

namespace InventoriaMauiApp.ViewModels
{
    public partial class ReservationDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ReservationDTO _reservation;
        private readonly IReservationStateService _reservationStateService;

        public ICommand NavigateBackCommand { get; }
        public ICommand OpenReservationContentCommand { get; }
        public ReservationDetailsViewModel(IReservationStateService reservationStateService)
        {
            _reservationStateService = reservationStateService;
            Reservation = _reservationStateService.CurrentReservationDTO;
            NavigateBackCommand = new Command(async () => await NavigateBack());
            OpenReservationContentCommand = new Command(async () => await OpenReservationContent());
        }

        private async Task NavigateBack()
        {
            await Shell.Current.GoToAsync("//ReservationOverviewPage");
        }

        private async Task OpenReservationContent()
        {
            await Shell.Current.GoToAsync("ReservedUnitsPage");
        }
    }
}
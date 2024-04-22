namespace InventoriaMauiApp.View;
using InventoriaMauiApp.ViewModels;
using InventoriaMauiApp;
using static InventoriaMauiApp.View.ReservationDetailsPage;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;
using InventoriaMauiApp.Models;
public partial class ReservationDetailsPage : ContentPage
{
    public ReservationDetailsPage(ReservationDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

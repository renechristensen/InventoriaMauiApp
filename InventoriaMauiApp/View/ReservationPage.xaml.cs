using InventoriaMauiApp;
using static InventoriaMauiApp.View.ReservationPage;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;
using InventoriaMauiApp.Models;

using InventoriaMauiApp.ViewModels;

namespace InventoriaMauiApp.View;

public partial class ReservationPage : ContentPage
{
    public ReservationPage(ReservationViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
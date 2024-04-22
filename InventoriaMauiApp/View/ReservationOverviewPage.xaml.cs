using InventoriaMauiApp;
using static InventoriaMauiApp.View.ReservationOverviewPage;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;
using InventoriaMauiApp.Models;

using InventoriaMauiApp.ViewModels;

namespace InventoriaMauiApp.View;

public partial class ReservationOverviewPage : ContentPage
{
    public ReservationOverviewPage(ReservationOverviewViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
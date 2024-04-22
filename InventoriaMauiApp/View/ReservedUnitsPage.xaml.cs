using InventoriaMauiApp;
using static InventoriaMauiApp.View.ReservedUnitsPage;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;
using InventoriaMauiApp.Models;

using InventoriaMauiApp.ViewModels;

namespace InventoriaMauiApp.View;

public partial class ReservedUnitsPage : ContentPage
{
    public ReservedUnitsPage(ReservationRackUnitsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
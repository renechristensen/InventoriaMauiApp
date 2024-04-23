using InventoriaMauiApp;
using static InventoriaMauiApp.View.ReservedRackUnitDetailsPage;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;
using InventoriaMauiApp.Models;

using InventoriaMauiApp.ViewModels;

namespace InventoriaMauiApp.View;

public partial class ReservedRackUnitDetailsPage : ContentPage
{
    public ReservedRackUnitDetailsPage(ReservedRackUnitDetailsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
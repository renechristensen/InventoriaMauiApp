using InventoriaMauiApp;
using static InventoriaMauiApp.View.RackUnitDetailsPage;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;
using InventoriaMauiApp.Models;

using InventoriaMauiApp.ViewModels;

namespace InventoriaMauiApp.View;

public partial class RackUnitDetailsPage : ContentPage
{
    public RackUnitDetailsPage(RackUnitDetailsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
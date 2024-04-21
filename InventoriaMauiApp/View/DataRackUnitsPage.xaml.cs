namespace InventoriaMauiApp.View;
using InventoriaMauiApp.ViewModels;
using InventoriaMauiApp;
using static InventoriaMauiApp.View.DataRackUnitsPage;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;
using InventoriaMauiApp.Models;

public partial class DataRackUnitsPage : ContentPage
{
    public DataRackUnitsPage(DataRackUnitsViewModel viewModel)
    {

        InitializeComponent();
        BindingContext = viewModel;
    }
}
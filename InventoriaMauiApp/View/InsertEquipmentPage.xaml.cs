namespace InventoriaMauiApp.View;
using InventoriaMauiApp.ViewModels;
using InventoriaMauiApp;
using static InventoriaMauiApp.View.InsertEquipmentPage;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;
using InventoriaMauiApp.Models;

public partial class InsertEquipmentPage : ContentPage
{
    public InsertEquipmentPage(EquipmentViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

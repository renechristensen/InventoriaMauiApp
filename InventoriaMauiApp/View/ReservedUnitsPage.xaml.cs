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
    public ReservedUnitsPage(ReservedUnitsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    private void OnReservedCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox && checkBox.BindingContext is RackUnitFlatDTO rackUnit)
        {
            var viewModel = (ReservedUnitsPageViewModel)BindingContext;
            viewModel.HandleCheckChanged(rackUnit, e.Value);
        }
    }
}
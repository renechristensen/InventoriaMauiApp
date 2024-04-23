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
    public DataRackUnitsPage(DataRackUnitsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox && checkBox.BindingContext is RackUnitFlatDTO rackUnit)
        {
            var viewModel = (DataRackUnitsPageViewModel)BindingContext;
            viewModel.HandleCheckChanged(rackUnit, e.Value);
        }
    }
}

namespace InventoriaMauiApp.View;
using InventoriaMauiApp.ViewModels;
using InventoriaMauiApp;
using static InventoriaMauiApp.View.DataRackOverViewPage;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;
using InventoriaMauiApp.Models;

public partial class DataRackOverViewPage : ContentPage
{
	public DataRackOverViewPage(DataRacksViewModel viewModel)
	{
		
		InitializeComponent();
        BindingContext = viewModel;
    }
}
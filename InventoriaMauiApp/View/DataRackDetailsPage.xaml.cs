namespace InventoriaMauiApp.View;
using InventoriaMauiApp.ViewModels;
using InventoriaMauiApp;
using static InventoriaMauiApp.View.DataRackDetailsPage;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;
using InventoriaMauiApp.Models;
public partial class DataRackDetailsPage : ContentPage
    {
        public DataRackDetailsPage(DataRackDetailsPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
    }
   }

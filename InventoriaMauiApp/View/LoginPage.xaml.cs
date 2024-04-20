namespace InventoriaMauiApp.View;
using InventoriaMauiApp.ViewModels;
using InventoriaMauiApp;
using static InventoriaMauiApp.View.LoginPage;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;
using InventoriaMauiApp.Models;
public partial class LoginPage : ContentPage
{
    public LoginPage(UserLoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel; 
    }
}
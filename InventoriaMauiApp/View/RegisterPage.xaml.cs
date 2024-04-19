using InventoriaMauiApp;
using static InventoriaMauiApp.Views.RegisterPage;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;
using InventoriaMauiApp.Models;

using InventoriaMauiApp.ViewModels;

namespace InventoriaMauiApp.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(UserRegisterViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
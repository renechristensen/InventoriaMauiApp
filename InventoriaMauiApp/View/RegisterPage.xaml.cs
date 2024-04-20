using InventoriaMauiApp;
using static InventoriaMauiApp.View.RegisterPage;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;
using InventoriaMauiApp.Models;

using InventoriaMauiApp.ViewModels;

namespace InventoriaMauiApp.View;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(UserRegisterViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
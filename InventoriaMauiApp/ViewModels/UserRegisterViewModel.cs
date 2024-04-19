using InventoriaMauiApp.Services;
using Microsoft.Maui.Controls;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using InventoriaMauiApp.Models;

namespace InventoriaMauiApp.ViewModels
{
    public class UserRegisterViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _gentagPassword;
        private string _studieEmail;
        private int _companyID;
        private List<Company> _companies;
        private Company _selectedCompany;

        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;

        public ICommand RegisterCommand { get; }

        public UserRegisterViewModel(IUserService userService, ICompanyService companyService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            RegisterCommand = new Command(async () => await OnRegisterClicked());
            _companyService = companyService;
            LoadCompanies();
        }

        public List<Company> Companies
        {
            get => _companies;
            set => Set(ref _companies, value);
        }

        public Company SelectedCompany
        {
            get => _selectedCompany;
            set
            {
                if (Set(ref _selectedCompany, value))
                {
                    CompanyID = _selectedCompany?.CompanyID ?? 0;
                }
            }
        }

        public string Username
        {
            get => _username;
            set => Set(ref _username, value);
        }
        public string StudieEmail
        {
            get => _studieEmail;
            set => Set(ref _studieEmail, value);
        }
        public int CompanyID
        {
            get => _companyID;
            set => Set(ref _companyID, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }
        public string GentagPassword
        {
            get => _gentagPassword;
            set => Set(ref _gentagPassword, value);
        }

        private async void LoadCompanies()
        {
            Companies = await _companyService.GetAllCompaniesAsync();
        }
        private async Task OnRegisterClicked()
        {
            if (string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(StudieEmail))
            {
                await Application.Current.MainPage.DisplayAlert("Validation Error", "All fields are required.", "OK");
                return;
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            var hasLowerChar = new Regex(@"[a-z]+");

            if (!(hasNumber.IsMatch(Password) &&
                  hasUpperChar.IsMatch(Password) &&
                  hasMinimum8Chars.IsMatch(Password) &&
                  hasLowerChar.IsMatch(Password)))
            {
                await Application.Current.MainPage.DisplayAlert("Validation Error", "Password should be a minimum of 8 characters, contain at least one uppercase letter, one lowercase letter, and one number.", "OK");
                return;
            }

            if (Password != GentagPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Passwords do not match.", "OK");
                return;
            }

            var emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            if (!Regex.IsMatch(StudieEmail, emailPattern))
            {
                await Application.Current.MainPage.DisplayAlert("Validation Error", "Please provide a valid email address.", "OK");
                return;
            }

            var newUser = new User
            {
                Displayname = Username,
                StudieEmail = StudieEmail,
                CompanyID = CompanyID,
                Password = Password
            };

            try
            {
                var responseMessage = await _userService.RegisterUserAsync(newUser);
                if (responseMessage == "true")
                {
                    await Shell.Current.GoToAsync("//LoginPage");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Registration Failed", responseMessage, "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "An error occurred during registration: " + ex.Message, "OK");
            }
        }
    }
}

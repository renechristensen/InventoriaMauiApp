using Microsoft.Maui.Controls;
using InventoriaMauiApp.Services;
using System.Windows.Input;
using System.Threading.Tasks;
using InventoriaMauiApp.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InventoriaMauiApp.ViewModels
{
    public class UserLoginViewModel : ViewModelBase
    {
        private string _email = string.Empty;
        private string _password = string.Empty;
        private readonly IUserService _userService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserStateService _userStateService;

        public ICommand LoginCommand { get; }

        public UserLoginViewModel(IUserService userService, IAuthorizationService authorizationService, IUserStateService userStateService)
        {
            _userService = userService;
            LoginCommand = new Command(async () => await OnLoginClicked());
            _authorizationService = authorizationService;
            _userStateService = userStateService;
        }

        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        private async Task OnLoginClicked()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                await Shell.Current.DisplayAlert("Fejl", "Vaer venlig at udfylde kodeord- og emailfeltet",
                    "OK");
                return;
            }

            try
            {
                var jsonString = await _userService.LoginAsync(Email, Password);
                var deserializedObject = JsonSerializer.Deserialize<Root>(jsonString);

                string? token = deserializedObject?.Token;
                User? user = deserializedObject?.User;

                if (!string.IsNullOrEmpty(token))
                {
                    _authorizationService.LogIn(token);
                    _userStateService.CurrentUser = new User() {
                        Roles = user.Roles,
                        CompanyID = user.CompanyID,
                        CompanyName = user.CompanyName,
                        CreationDate = user.CreationDate,
                        Displayname = user.Displayname,
                        LastLoginDate = user.LastLoginDate,
                        StudieEmail = user.StudieEmail,
                        UserID = user.UserID
                        // Skip password for security
                    };
                    await Shell.Current.GoToAsync("//DataRackOverView");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Login fejlede", "Du har brugt en forkert email eller password", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Fejl", $"Der opstod desvaerre en database fejl" +
                    $" da du forsøgte at logge ind, kontakt en administrator med følgende besked: {ex.Message}", "OK");
            }
        }

        private class Root
        {
            [JsonPropertyName("login")]
            public User? User { get; set; }

            [JsonPropertyName("token")]
            public string? Token { get; set; }
        }
    }
}

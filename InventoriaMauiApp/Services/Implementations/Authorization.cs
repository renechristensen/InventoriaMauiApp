using Microsoft.Maui.Storage;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public event Action<bool>? AuthenticationStateChanged;

        private readonly string _tokenKey = "auth_token";
        private readonly TimeZoneInfo _danishTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");

        public async Task<string> GetAuthorizationTokenAsync()
        {
            var token = await SecureStorage.GetAsync(_tokenKey);
            if (string.IsNullOrEmpty(token) || IsTokenExpired(token))
            {
                LogOut();
                AuthenticationStateChanged?.Invoke(false);
                return "";
            }
            return token;
        }

        private bool IsTokenExpired(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(token))
            {
                throw new ArgumentException("The token is invalid and cannot be read.");
            }

            var jwtToken = handler.ReadJwtToken(token);
            var expiryDate = jwtToken.ValidTo;
            var expiryDateLocal = TimeZoneInfo.ConvertTimeFromUtc(expiryDate, _danishTimeZone);

            return expiryDateLocal <= DateTime.Now;
        }

        public void LogOut()
        {
            SecureStorage.Remove(_tokenKey);
            AuthenticationStateChanged?.Invoke(false);
        }

        public void LogIn(string token)
        {
            SecureStorage.SetAsync("auth_token", token);
            AuthenticationStateChanged?.Invoke(true);
        }
    }
}

using InventoriaMauiApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public async Task<string> GetAuthorizationTokenAsync()
        {
            var token = await SecureStorage.GetAsync("auth_token");
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Token is missing or invalid");
            }
            return token;
        }
    }
}
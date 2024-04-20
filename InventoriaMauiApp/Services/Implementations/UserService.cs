using InventoriaMauiApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly string LoginEndpoint = "api/Login/";
        private readonly string RegisterEndpoint = "api/User/";

        public UserService(HttpClient httpClient, IAuthorizationService authorizationService)
            : base(httpClient, authorizationService)
        {
        }

        public async Task<string> LoginAsync(string studieEmail, string passwordHash)
        {
            var jsonPayload = JsonConvert.SerializeObject(new
            {
                StudieEmail = studieEmail,
                PasswordHash = passwordHash
            });

            StringContent message = new(jsonPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await ExecuteHttpRequestAsyncWithoutAuthorization(() => _httpClient.PostAsync(LoginEndpoint, message));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"Failed to login: {response.StatusCode}");
            }
        }

        public async Task<string> RegisterUserAsync(User userToRegister)
        {
            var jsonPayload = JsonConvert.SerializeObject(userToRegister);
            StringContent message = new(jsonPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await ExecuteHttpRequestAsyncWithoutAuthorization(() => _httpClient.PostAsync(RegisterEndpoint + "CreateUser", message));

            if (response.IsSuccessStatusCode)
            {
                return "true";
            }
            else
            {
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            var endpoint = $"api/User/{userId}";

            HttpResponseMessage response = await ExecuteHttpRequestAsync(() => _httpClient.GetAsync(endpoint));

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                User getUser = JsonConvert.DeserializeObject<User>(jsonResponse) ?? new User();
                return getUser;
            }
            else
            {
                throw new Exception($"Failed to fetch user: {response.StatusCode}");
            }
        }
    }
}

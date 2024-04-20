using InventoriaMauiApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Services
{
    public class CompanyService : BaseService, ICompanyService
    {
        private readonly string CompanyEndpoint = "api/Company/";

        public CompanyService(HttpClient httpClient, IAuthorizationService authorizationService)
            : base(httpClient, authorizationService)
        {
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            HttpResponseMessage response = await ExecuteHttpRequestAsyncWithoutAuthorization(() => _httpClient.GetAsync(CompanyEndpoint));

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Company>>(jsonResponse);
            }
            else
            {
                throw new Exception($"Failed to retrieve companies: {response.StatusCode}");
            }
        }
    }
}


using InventoriaMauiApp.Models;
using InventoriaMauiApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Services
{
    public class RackUnitService : BaseService, IRackUnitService
    {
        private readonly string RackUnitEndpoint = "api/RackUnit/";

        public RackUnitService(HttpClient httpClient, IAuthorizationService authorizationService)
            : base(httpClient, authorizationService)
        {
        }

        public async Task<List<RackUnitFlatDTO>> GetAllRackUnitsByDataRackIdAsync(int dataRackId)
        {
            HttpResponseMessage response = await ExecuteHttpRequestAsync(() => _httpClient.GetAsync($"{RackUnitEndpoint}{dataRackId}"));

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<RackUnitFlatDTO>>(jsonResponse) ?? new List<RackUnitFlatDTO>();
            }
            else
            {
                throw new Exception($"Failed to retrieve rack units for Data Rack ID {dataRackId}: {response.StatusCode}");
            }
        }
    }
}

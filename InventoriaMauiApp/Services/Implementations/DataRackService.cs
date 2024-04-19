using InventoriaMauiApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Services
{
    public class DataRackService : BaseService, IDataRackService
    {
        private readonly string DataRackEndpoint = "api/DataRack/";

        public DataRackService(HttpClient httpClient, IAuthorizationService authorizationService)
            : base(httpClient, authorizationService)
        {
        }

        public async Task<List<DataRack>> GetAllDataRacksAsync()
        {
            HttpResponseMessage response = await ExecuteHttpRequestAsync(() => _httpClient.GetAsync(DataRackEndpoint));

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DataRack>>(jsonResponse);
            }
            else
            {
                throw new Exception($"Failed to retrieve data racks: {response.StatusCode}");
            }
        }

        public async Task<DataRack> GetDataRackByIdAsync(int dataRackId)
        {
            HttpResponseMessage response = await ExecuteHttpRequestAsync(() => _httpClient.GetAsync($"{DataRackEndpoint}{dataRackId}"));

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DataRack>(jsonResponse);
            }
            else
            {
                throw new Exception($"Failed to retrieve data rack with ID {dataRackId}: {response.StatusCode}");
            }
        }
    }
}

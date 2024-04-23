using InventoriaMauiApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Services
{
    public class EquipmentService : BaseService, IEquipmentService
    {
        private readonly string EquipmentEndpoint = "api/Equipment/";

        public EquipmentService(HttpClient httpClient, IAuthorizationService authorizationService)
            : base(httpClient, authorizationService)
        {
        }

        public async Task<EquipmentDTO> GetEquipmentById(int equipmentId)
        {
            HttpResponseMessage response = await ExecuteHttpRequestAsync(() => _httpClient.GetAsync($"{EquipmentEndpoint}{equipmentId}"));

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EquipmentDTO>(jsonResponse);
            }
            else
            {
                throw new Exception($"Failed to retrieve equipment with ID {equipmentId}: {response.StatusCode}");
            }
        }

        public async Task<EquipmentDTO> CreateEquipment(CreateEquipmentDTO equipment)
        {
            var json = JsonConvert.SerializeObject(equipment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await ExecuteHttpRequestAsync(() => _httpClient.PostAsync(EquipmentEndpoint, content));

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EquipmentDTO>(jsonResponse);
            }
            else
            {
                throw new Exception($"Failed to create equipment: {response.StatusCode}");
            }
        }

        public async Task<bool> UpdateEquipment(int equipmentId, UpdateEquipmentDTO equipment)
        {
            var json = JsonConvert.SerializeObject(equipment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await ExecuteHttpRequestAsync(() => _httpClient.PutAsync($"{EquipmentEndpoint}{equipmentId}", content));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteEquipment(int equipmentId)
        {
            HttpResponseMessage response = await ExecuteHttpRequestAsync(() => _httpClient.DeleteAsync($"{EquipmentEndpoint}{equipmentId}"));

            return response.IsSuccessStatusCode;
        }

        // New method to delete equipment by RackUnitID
        public async Task<bool> DeleteEquipmentByRackUnitId(int rackUnitId)
        {
            HttpResponseMessage response = await ExecuteHttpRequestAsync(() => _httpClient.DeleteAsync($"{EquipmentEndpoint}ByRackUnit/{rackUnitId}"));

            return response.IsSuccessStatusCode;
        }
    }
}

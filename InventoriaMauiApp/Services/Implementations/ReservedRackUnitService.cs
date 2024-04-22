using InventoriaMauiApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Services
{
    public class ReservedRackUnitsService : BaseService, IReservedRackUnitsService
    {
        private readonly string ReservedRackUnitEndpoint = "api/ReservedRackUnit/ByReservation/";

        public ReservedRackUnitsService(HttpClient httpClient, IAuthorizationService authorizationService)
            : base(httpClient, authorizationService)
        {
        }

        public async Task<List<RackUnitFlatDTO>> GetReservedRackUnitsByReservationIdAsync(int reservationId)
        {
            HttpResponseMessage response = await ExecuteHttpRequestAsync(() => _httpClient.GetAsync($"{ReservedRackUnitEndpoint}{reservationId}"));

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<RackUnitFlatDTO>>(jsonResponse) ?? new List<RackUnitFlatDTO>();
            }
            else
            {
                throw new Exception($"Failed to retrieve reserved rack units for Reservation ID {reservationId}: {response.StatusCode}");
            }
        }
    }
}

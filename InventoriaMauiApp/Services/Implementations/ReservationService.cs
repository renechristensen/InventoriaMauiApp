using InventoriaMauiApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Services
{
    public class ReservationService : BaseService, IReservationService
    {
        private readonly string ReservationEndpoint = "api/Reservation/";

        public ReservationService(HttpClient httpClient, IAuthorizationService authorizationService)
            : base(httpClient, authorizationService)
        {
        }

        public async Task<ReservationDTO> CreateReservation(CreateReservationDTO reservation)
        {
            var json = JsonConvert.SerializeObject(reservation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await ExecuteHttpRequestAsync(() => _httpClient.PostAsync(ReservationEndpoint, content));

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ReservationDTO>(jsonResponse);
            }
            else
            {
                throw new Exception($"Failed to create reservation: {response.StatusCode}");
            }
        }

        public async Task<List<ReservationDTO>> GetReservationsByUser(int userId)
        {
            HttpResponseMessage response = await ExecuteHttpRequestAsync(() => _httpClient.GetAsync($"{ReservationEndpoint}user/{userId}"));

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ReservationDTO>>(jsonResponse) ?? new List<ReservationDTO>();
            }
            else
            {
                throw new Exception($"Failed to retrieve reservations for user {userId}: {response.StatusCode}");
            }
        }

        public async Task<ReservationDTO> GetReservationById(int reservationId)
        {
            HttpResponseMessage response = await ExecuteHttpRequestAsync(() => _httpClient.GetAsync($"{ReservationEndpoint}{reservationId}"));

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ReservationDTO>(jsonResponse);
            }
            else
            {
                throw new Exception($"Failed to retrieve reservation with ID {reservationId}: {response.StatusCode}");
            }
        }
    }
}

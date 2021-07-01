using PlannerApp.Client.Services.Exceptions;
using PlannerApp.Client.Services.Interfaces;
using PlannetApp.Shared.Models;
using PlannetApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Client.Services
{
    public class HttpAuthentiactionService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        public HttpAuthentiactionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse> RegisterUserRequsertAsync(RegisterRequest model)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v2/auth/register", model);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                return result;
            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                throw new ApiException(errorResponse, response.StatusCode);
            }
        }
    }
}

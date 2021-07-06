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
    class HttpPlansService : IPlansServices
    {
        private readonly HttpClient _httpClient;

        public HttpPlansService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<PageList<PlanSummary>>> GetPlansAsync(string query = null, int pageSize = 10, int pageNumber = 1)
        {
            var response = await _httpClient.GetAsync($"/api/v2/plans?query={query}&pagenumber={pageNumber}&pagesize={pageSize}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse<PageList<PlanSummary>>>();
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

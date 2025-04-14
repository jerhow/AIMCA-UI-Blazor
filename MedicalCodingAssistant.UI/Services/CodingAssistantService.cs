using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using MedicalCodingAssistant.UI.Settings;
using MedicalCodingAssistant.UI.Models;

namespace MedicalCodingAssistant.UI.Services
{
    public class CodingAssistantService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public CodingAssistantService(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClientFactory.CreateClient("MedicalCodingAPI");
            _apiSettings = apiSettings.Value;
        }

        /// <summary>
        /// Sends a POST request to the ICD-10 API endpoint with the query and maxResults parameters.
        /// The response is deserialized into an ICD10SearchResponse object.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="maxResults"></param>
        /// <returns></returns>
        public async Task<ICD10SearchResponse?> SearchICD10Async(string query, int maxResults = 3)
        {
            var requestBody = new
            {
                query = query,
                maxSqlResults = maxResults
            };

            var response = await _httpClient.PostAsJsonAsync("/api/SearchICD10", requestBody);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ICD10SearchResponse>();
            return result;
        }
    }
}

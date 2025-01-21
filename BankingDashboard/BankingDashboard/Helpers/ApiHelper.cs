using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace BankingDashboard.Helpers
{
    public class ApiHelper
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApiHelper(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }       


        // Generic method to call a POST API and return a response of type TResponse
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest data)
        {
            // Serialize the request data to JSON
            string json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var token = _httpContextAccessor.HttpContext?.Session.GetString("AuthToken");
                if(token!=null)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                
                // Send POST request
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                // Ensure success status code
                response.EnsureSuccessStatusCode();

                // Read and deserialize the response
                string responseBody = await response.Content.ReadAsStringAsync();
                TResponse result = JsonSerializer.Deserialize<TResponse>(responseBody);

                return result;
            }
            catch (HttpRequestException ex)
            {
                // Log or handle specific errors
                throw new Exception($"Request failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other errors
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Generic method to call an API and return a response.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request body.</typeparam>
        /// <typeparam name="TResponse">The type of the response body.</typeparam>
        /// <param name="url">The API endpoint.</param>
        /// <param name="method">The HTTP method (GET, POST, PUT, DELETE).</param>
        /// <param name="data">The request body (for POST/PUT).</param>
        /// <returns>The response object of type TResponse.</returns>
        public async Task<TResponse> CallApiAsync<TRequest, TResponse>(string url, HttpMethod method, TRequest data = default)
        {
            try
            {
                // Create an HTTP request
                var request = new HttpRequestMessage
                {
                    Method = method,
                    RequestUri = new Uri(url)
                };

                // Add JSON body for POST or PUT methods
                if (data != null && (method == HttpMethod.Post || method == HttpMethod.Put))
                {
                    string jsonData = JsonSerializer.Serialize(data);
                    request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                }
                var token = _httpContextAccessor.HttpContext?.Session.GetString("AuthToken");
                if (token != null)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                // Send the request
                var response = await _httpClient.SendAsync(request);

                // Throw an exception if the response indicates an error
                response.EnsureSuccessStatusCode();

                // Read and deserialize the response content
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                // Handle exceptions (log them or rethrow as needed)
                throw new ApplicationException($"Error calling API: {ex.Message}", ex);
            }
        }
    }

}

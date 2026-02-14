using Asp.NetHw5.Models;
using System.Text.Json;


namespace Asp.NetHw5.Services
{
    public class TmdbService
    {
        private readonly HttpClient _httpClient;

        public TmdbService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MovieResponse?> GetMoviesAsync()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            };

            var response = await _httpClient.GetAsync("movie/popular");
            response.EnsureSuccessStatusCode();

            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<MovieResponse>(jsonString, options);
        }
    }
}

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Globalization;
using AirQuality.Application.DTOs;
using AirQuality.Application.Interfaces;


namespace AirQuality.Infrastructure.ExternalServices
{
    public class OpenMeteoClient : IExternalWeatherClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OpenMeteoClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ExternalWeatherResponseDTO> GetCurrentWeatherAsync(double latitude, double longitude)
        {
            // formate isso usando as regras globais da computação, não importa em qual país este servidor esteja rodando
            string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude.ToString(CultureInfo.InvariantCulture)}&longitude={longitude.ToString(CultureInfo.InvariantCulture)}&current=temperature_2m,relative_humidity_2m";
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();

            // --- A MÁGICA QUE FALTAVA AQUI ---
            // Isso avisa o C# para ignorar se a letra é maiúscula ou minúscula
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<ExternalWeatherResponseDTO>(jsonString, options);
        }
    }
}
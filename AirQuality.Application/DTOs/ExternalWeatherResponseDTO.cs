using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AirQuality.Application.DTOs
{
    public class ExternalWeatherResponseDTO
    {
        // Procura a palavra "current" no JSON
        [JsonPropertyName("current")]
        public CurrentWeatherDTO Current { get; set; }

        public class CurrentWeatherDTO
        {
            [JsonPropertyName("temperature_2m")]
            public decimal Temperature { get; set; }

            [JsonPropertyName("relative_humidity_2m")]
            public decimal Humidity { get; set; }
        }
    }
}

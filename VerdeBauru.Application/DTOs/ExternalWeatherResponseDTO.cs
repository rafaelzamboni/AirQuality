using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VerdeBauru.Application.DTOs
{
    public class ExternalWeatherResponseDTO
    {
        // Procura a palavra "current" no JSON e colocar aqui dentro
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

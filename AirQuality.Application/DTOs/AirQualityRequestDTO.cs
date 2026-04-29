using System;
using System.Collections.Generic;
using System.Text;

namespace AirQuality.Application.DTOs
{
    public class AirQualityRequestDTO
    {
        public string Location { get; set; } = string.Empty;
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AirQuality.Application.DTOs
{
    public class AirQualityResponseDTO
    {
        public Guid Id { get; set; }
        public string Location { get; set; } = string.Empty;
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        public string Status { get; set; }
        public DateTime RecordAt { get; set; }
    }
}

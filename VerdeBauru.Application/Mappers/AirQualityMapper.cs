using VerdeBauru.Application.DTOs;
using VerdeBauru.Domain.Entities;

namespace VerdeBauru.Application.Mappers
{
    public static class AirQualityMapper
    { 
        public static AirQualityRecord ToEntity(this AirQualityRequestDTO dto)
        {
            return new AirQualityRecord
            {
                Location = dto.Location,
                Temperature = dto.Temperature,
                Humidity = dto.Humidity
            };
        }

        public static AirQualityResponseDTO ToDTO(this AirQualityRecord entity)
        {
            return new AirQualityResponseDTO
            {
                Id = entity.Id,
                Location = entity.Location ?? "Desconhecido",
                Temperature = entity.Temperature,
                Humidity = entity.Humidity,
                IsFireAlert = entity.IsFireAlert,
                RecordAt = entity.RecordAt
            };
        }
    }
}
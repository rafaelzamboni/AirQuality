using AirQuality.Application.DTOs;
using AirQuality.Domain.Entities;

namespace AirQuality.Application.Mappers
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
                Status = entity.Status.ToString(),
                RecordAt = entity.RecordAt
            };
        }
    }
}
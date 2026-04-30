using System.Threading.Tasks;
using AirQuality.Application.DTOs;

namespace AirQuality.Application.Interfaces
{
    public interface IAirQualityService
    {
        Task<AirQualityResponseDTO> AddRecordAsync(AirQualityRequestDTO dto);

        Task<PagedResponseDTO<AirQualityResponseDTO>> GetPagedRecordsAsync(int page, int pageSize, string? location);

        Task<AirQualityResponseDTO> FetchAndSaveExternalWeatherAsync(string location, double latitude, double longitude);
    }
}
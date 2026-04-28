using System.Threading.Tasks;
using VerdeBauru.Application.DTOs;

namespace VerdeBauru.Application.Interfaces
{
    public interface IAirQualityService
    {
        // Tem que estar exatamente igualzinho ao que está na sua imagem!
        Task<AirQualityResponseDTO> AddRecordAsync(AirQualityRequestDTO dto);

        Task<PagedResponseDTO<AirQualityResponseDTO>> GetPagedRecordsAsync(int page, int pageSize, string? location);

        // Vai receber a latitude, longitude e o nome do lugar para salvar no banco
        Task<AirQualityResponseDTO> FetchAndSaveExternalWeatherAsync(string location, double latitude, double longitude);
    }
}
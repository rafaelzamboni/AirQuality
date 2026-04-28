using System.Threading.Tasks;
using VerdeBauru.Application.DTOs;

namespace VerdeBauru.Application.Interfaces
{
    public interface IExternalWeatherClient
    {
        Task<ExternalWeatherResponseDTO> GetCurrentWeatherAsync(double latitude, double longitude);
    }
}
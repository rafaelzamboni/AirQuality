using System.Threading.Tasks;
using AirQuality.Application.DTOs;

namespace AirQuality.Application.Interfaces
{
    public interface IExternalWeatherClient
    {
        Task<ExternalWeatherResponseDTO> GetCurrentWeatherAsync(double latitude, double longitude);
    }
}
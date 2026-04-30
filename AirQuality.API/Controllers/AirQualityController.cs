using Microsoft.AspNetCore.Mvc;
using AirQuality.Application.DTOs;
using AirQuality.Application.Interfaces;

namespace AirQuality.API.Controllers
{
    // A rota será http://localhost:porta/api/airquality
    [Route("api/[controller]")]
    [ApiController]
    public class AirQualityController : ControllerBase
    {
        private readonly IAirQualityService _service;

        // Injeção de Dependência
        public AirQualityController(IAirQualityService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AirQualityRequestDTO request)
        {
            var response = await _service.AddRecordAsync(request);

            // Retorna o HTTP Status 201 (Created) e o DTO com o resultado
            return Created(string.Empty, response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? location = null)
        {
            // O [FromQuery] avisa a API que esses dados vão vir na URL (ex: ?page=1&location=Centro)

            var result = await _service.GetPagedRecordsAsync(page, pageSize, location);

            return Ok(result); // Retorna HTTP 200 com o JSON
        }

        [HttpPost("external")]
        public async Task<IActionResult> FetchFromExternalApi(
            [FromQuery] string location,
            [FromQuery] double latitude,
            [FromQuery] double longitude)
        {

            try
            {
                // Tenta fazer a busca e salvar
                var response = await _service.FetchAndSaveExternalWeatherAsync(location, latitude, longitude);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }
    }
}
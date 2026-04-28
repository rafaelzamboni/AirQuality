using Microsoft.AspNetCore.Mvc;
using VerdeBauru.Application.DTOs;
using VerdeBauru.Application.Interfaces;

namespace VerdeBauru.API.Controllers
{
    // A rota será http://localhost:porta/api/airquality
    [Route("api/[controller]")]
    [ApiController]
    public class AirQualityController : ControllerBase
    {
        private readonly IAirQualityService _service;

        // Injeção de Dependência: A API pede o "Gerente" (Service)
        public AirQualityController(IAirQualityService service)
        {
            _service = service;
        }

        // Método POST para receber o JSON do sensor
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AirQualityRequestDTO request)
        {
            // O Controller não tem regra de negócio. Ele só passa a bola para o Service.
            var response = await _service.AddRecordAsync(request);

            // Retorna o HTTP Status 201 (Created) e o DTO com o resultado (incluindo se teve alerta de fogo)
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
                // Se o Service lançar nosso erro de "Já existe", capturamos aqui!
                // Retorna um HTTP 400 com um JSON limpo, sem quebrar o Swagger.
                return BadRequest(new { Erro = ex.Message });
            }
        }
    }
}
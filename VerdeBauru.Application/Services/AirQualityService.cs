using System.Threading.Tasks;
using VerdeBauru.Application.DTOs;
using VerdeBauru.Application.Interfaces;
using VerdeBauru.Application.Mappers;
using VerdeBauru.Domain.Interfaces;

namespace VerdeBauru.Application.Services
{
    public class AirQualityService : IAirQualityService
    {
        private readonly IAirQualityRepository _repository;
        private readonly IExternalWeatherClient _weatherClient;

        public AirQualityService(IAirQualityRepository repository, IExternalWeatherClient weatherClient)
        {
            _repository = repository;
            _weatherClient = weatherClient;
        }

        public async Task<AirQualityResponseDTO> AddRecordAsync(AirQualityRequestDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Location))
            {
                throw new Exception("Localização é obrigatória.");
            }

            // Verifica se já existe um registro para a mesma localização no mesmo dia
            var alreadyExists = await _repository.AnyForLocationTodayAsync(dto.Location);

            if (alreadyExists) 
            {
                throw new Exception($"Já existe uma medição para '{dto.Location}' no dia de hoje.");
            }

            var entity = dto.ToEntity();
            entity.CheckForFireAlert();

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return entity.ToDTO();
        }

        public async Task<PagedResponseDTO<AirQualityResponseDTO>> GetPagedRecordsAsync(int page, int pageSize, string? location)
        {
            // 1. Pega os dados crus do Banco de Dados (Entidades)
            var (items, totalCount) = await _repository.GetPagedAsync(page, pageSize, location);

            // 2. Converte a lista de Entidades para a lista de DTOs (Proteção dos dados)
            var dtoList = items.Select(x => x.ToDTO()).ToList();

            // 3. Calcula o total de páginas (Ex: 25 itens / 10 por página = 3 páginas)
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            // 4. Monta a resposta final
            return new PagedResponseDTO<AirQualityResponseDTO>
            {
                Data = dtoList,
                PageNumber = page,
                TotalPages = totalPages,
                TotalRecords = totalCount
            };
        }

        public async Task<AirQualityResponseDTO> FetchAndSaveExternalWeatherAsync(string location, double latitude, double longitude)
        {
            // 1. O Service vai na internet pedir os dados
            var externalData = await _weatherClient.GetCurrentWeatherAsync(latitude, longitude);

            // 2. A TRAVA DE SEGURANÇA (Logo abaixo da linha que você me mandou!)
            if (externalData == null || externalData.Current == null)
            {
                // Se a API não mandar o "current", a gente lança um erro limpo para o Swagger, e não aquele erro feio de NullReferenceException.
                throw new Exception("A API da Open-Meteo não retornou os dados corretamente (o objeto 'Current' veio nulo).");
            }

            // 3. Monta o DTO com segurança (agora temos certeza que o Current existe)
            var requestDto = new AirQualityRequestDTO
            {
                Location = location,
                Temperature = externalData.Current.Temperature,
                Humidity = externalData.Current.Humidity
            };

            // 4. Salva no banco com a nossa regra de "1 por dia"
            return await AddRecordAsync(requestDto);
        }
    }
}
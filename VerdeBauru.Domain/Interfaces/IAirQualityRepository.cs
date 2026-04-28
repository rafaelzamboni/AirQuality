using VerdeBauru.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace VerdeBauru.Domain.Interfaces
{
    public interface IAirQualityRepository
    {
        Task<IEnumerable<AirQualityRecord>> GetAllAsync();
        Task<AirQualityRecord?> GetByIdAsync(Guid id);
        // Retorna uma Tupla (A lista de itens E o número total de registros)
        Task<(IEnumerable<AirQualityRecord> Items, int TotalCount)> GetPagedAsync(int page, int pageSize, string? location);
        Task AddAsync(AirQualityRecord record);
        Task SaveChangesAsync();

        // Verifica se já existe qualquer registro para aquela localização na data de hoje
        Task<bool> AnyForLocationTodayAsync(string location);
    }
}
using Microsoft.EntityFrameworkCore;
using AirQuality.Domain.Entities;
using AirQuality.Domain.Interfaces;
using AirQuality.Infrastructure.Context;

namespace AirQuality.Infrastructure.Repositories
{
    public class AirQualityRepository : IAirQualityRepository
    {
        private readonly AirQualityDbContext _context;

        public AirQualityRepository(AirQualityDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AirQualityRecord record)
        {
            // Adiciona o registro na memória do Entity Framework
            await _context.AirQualityRecords.AddAsync(record);
        }

        public async Task<IEnumerable<AirQualityRecord>> GetAllAsync()
        {
            // Vai no banco, pega tudo e transforma numa lista (AsNoTracking deixa a consulta mais rápida pois não monitora variáveis na memória)
            return await _context.AirQualityRecords.AsNoTracking().ToListAsync();
        }

        public async Task<AirQualityRecord?> GetByIdAsync(Guid id)
        {
            return await _context.AirQualityRecords.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<(IEnumerable<AirQualityRecord> Items, int TotalCount)> GetPagedAsync(int page, int pageSize, string? location)
        {
            // AsQueryable prepara a query, mas não vai no banco ainda
            var query = _context.AirQualityRecords.AsQueryable();

            // Filtro por localização (se enviado)
            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(x => x.Location.Contains(location));
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.RecordAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task SaveChangesAsync()
        {
            // Dispara o comando real de INSERT/UPDATE para o banco de dados
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyForLocationTodayAsync(string location)
        {
            var today = DateTime.UtcNow.Date;

            // O EF Core vai traduzir isso para um comando "EXISTS" no SQL
            return await _context.AirQualityRecords
                .AnyAsync(x => x.Location == location && x.RecordAt.Date == today);
        }
    }
}

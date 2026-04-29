using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AirQuality.Domain.Entities;

namespace AirQuality.Infrastructure.Context
{
    // A classe herda de DbContext (que vem do pacote Npgsql.EntityFrameworkCore.PostgreSQL)
    public class AirQualityDbContext : DbContext
    {
        // Esse construtor recebe as opções de conexão (como a string do banco)
        public AirQualityDbContext(DbContextOptions<AirQualityDbContext> options) : base(options)
        {
        }

        // Cria uma tabela no banco chamada AirQualityRecords baseada nesta Entidade
        public DbSet<AirQualityRecord> AirQualityRecords { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VerdeBauru.Domain.Entities;

namespace VerdeBauru.Infrastructure.Context
{
    // A classe herda de DbContext (que vem do pacote Npgsql.EntityFrameworkCore.PostgreSQL)
    public class VerdeBauruDbContext : DbContext
    {
        // Esse construtor recebe as opções de conexão (como a string do banco)
        public VerdeBauruDbContext(DbContextOptions<VerdeBauruDbContext> options) : base(options)
        {
        }

        // Cria uma tabela no banco chamada AirQualityRecords baseada nesta Entidade
        public DbSet<AirQualityRecord> AirQualityRecords { get; set; }
    }
}

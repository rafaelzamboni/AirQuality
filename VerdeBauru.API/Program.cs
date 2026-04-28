using Microsoft.EntityFrameworkCore;
using VerdeBauru.Application.Interfaces;
using VerdeBauru.Application.Services;
using VerdeBauru.Domain.Interfaces;
using VerdeBauru.Infrastructure.Context;
using VerdeBauru.Infrastructure.ExternalServices;
using VerdeBauru.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Procura string de conexão no arquivo appsettings.json
builder.Services.AddDbContext<VerdeBauruDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// AddScoped significa: Crie uma nova instância para cada requisição HTTP que chegar.
builder.Services.AddScoped<IAirQualityRepository, AirQualityRepository>();
builder.Services.AddScoped<IAirQualityService, AirQualityService>();
// Registra o HttpClient para ser injetado em outros lugares (como o OpenMeteoClient)
builder.Services.AddHttpClient();
// "Quando o sistema pedir o IExternalWeatherClient, entregue o OpenMeteoClient da Infraestrutura"
builder.Services.AddScoped<IExternalWeatherClient, OpenMeteoClient>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Gera a documentação visual da API

var app = builder.Build();

// Configura a tela do Swagger para aparecer no navegador
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run(); // Inicia o servidor!
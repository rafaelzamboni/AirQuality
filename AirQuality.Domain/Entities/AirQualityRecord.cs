using System;
using System.Collections.Generic;
using System.Text;
using AirQuality.Domain.Enums;

namespace AirQuality.Domain.Entities
{
    public class AirQualityRecord
    {
        //Guid cria um identificador único para cada registro de qualidade do ar, garantindo que cada registro possa ser diferenciado dos outros, mesmo que tenham os mesmos valores para os outros campos.
        //Ao invés de usar inteiros sequenciais, o uso de Guid permite uma identificação mais robusta e segura, especialmente em sistemas distribuídos ou quando os registros podem ser criados em diferentes momentos ou por diferentes fontes.
        public Guid Id { get; set; } = Guid.NewGuid();

        //? Pode conter um valor nulo.
        public string? Location { get; set; }

        public decimal Temperature { get; set; }

        public decimal Humidity { get; set; }

        public AirQualityStatus Status { get; private set; }

        // 'UtcNow' salva no padrão universal para evitar problemas de fuso horário.
        public DateTime RecordAt { get; set; } = DateTime.UtcNow;

        public void CalculateAirQuality()
        {
            Status = (Temperature, Humidity) switch
            {
                ( >= 35, <= 30) => AirQualityStatus.Perigosa,
                ( >= 30, <= 40) => AirQualityStatus.Ruim,
                ( >= 25, <= 50) => AirQualityStatus.Moderada,
                _ => AirQualityStatus.Boa // O underline (_) significa o "default"
            };
        }
    }
}

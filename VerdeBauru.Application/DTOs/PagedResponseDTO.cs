using System.Collections.Generic;

namespace VerdeBauru.Application.DTOs
{
    // O <T> significa que ela é Genérica. Pode paginar Qualidade do Ar, Chamados, Usuários...
    public class PagedResponseDTO<T>
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
}
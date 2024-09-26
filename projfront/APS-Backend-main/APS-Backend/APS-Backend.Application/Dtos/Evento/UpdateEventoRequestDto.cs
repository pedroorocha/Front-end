using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Application.Dtos.Evento
{
    public class UpdateEventoRequestDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Tema { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
        public string Hora { get; set; } = string.Empty;
        public int HorasComplementares { get; set; }
        public int QtdMaximaParticipantes { get; set; }
        public string Palestrantes { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}

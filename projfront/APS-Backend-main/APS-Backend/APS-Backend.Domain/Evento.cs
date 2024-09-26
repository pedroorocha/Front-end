using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Domain
{
    public class Evento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ProfessorId { get; set; }
        public Professor? Professor { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;   
        public string Tema { get; set; } = string.Empty;
        public DateOnly Data { get; set; }
        public TimeOnly Hora { get; set; }
        public int HorasComplementares { get; set; }
        public int QtdMaximaParticipantes { get; set; }
        public string Palestrantes { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int? FilaEsperaId { get; set; }
        public FilaEspera? FilaEspera { get; set; }
        public List<AlunoEvento> AlunoEventos { get; set; } = new List<AlunoEvento>();
    }
}

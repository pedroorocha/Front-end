using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Domain
{
    public class AlunoEvento
    {
        public int EventoId { get; set; }
        public Evento? Evento { get; set; }
        public int AlunoId { get; set; }
        public Aluno? Aluno { get; set; }
        public StatusAluno Status { get; set; }
    }
}

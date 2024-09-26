using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Domain
{
    public class AlunoEspera
    {
        public int AlunoId { get; set; }
        public Aluno? Aluno { get; set; }
        public int FilaEsperaId { get; set; }
        public FilaEspera? FilaEspera { get; set; }
        public DateOnly DataInscricao { get; set; }
        public TimeOnly HoraInscricao { get; set; }
    }
}

using APS_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Persistence.Interfaces
{
    public interface IAlunoEsperaPersist
    {
        Task<AlunoEspera> GetAlunoEsperaByMatriculaAndEventoIdAsync(int matricula, int EventoId);
    }
}

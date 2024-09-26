using APS_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Persistence.Interfaces
{
    public interface IAlunoEventoPersist
    {
        Task<AlunoEvento> GetAlunoEventoByMatriculaAndEventoIdAsync(int matricula, int EventoId);

        Task<AlunoEvento[]> GetAlunoEventosByEventosIdAsync(int EventoId);
    }
}

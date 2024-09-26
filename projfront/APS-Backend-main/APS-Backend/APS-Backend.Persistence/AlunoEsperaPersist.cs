using APS_Backend.Domain;
using APS_Backend.Persistence.Context;
using APS_Backend.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Persistence
{
    public class AlunoEsperaPersist : IAlunoEsperaPersist
    {
        private readonly APSBackendDBContext _context;

        public AlunoEsperaPersist(APSBackendDBContext context)
        {
            _context = context;
        }

        public async Task<AlunoEspera> GetAlunoEsperaByMatriculaAndEventoIdAsync(int matricula, int EventoId)
        {
            IQueryable<AlunoEspera> query = _context.AlunoEsperas.AsQueryable();

            query = query
                    .AsNoTracking()
                    .Where(ae => ae.AlunoId == matricula)
                    .Where(ae => ae.FilaEspera.EventoId == EventoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}

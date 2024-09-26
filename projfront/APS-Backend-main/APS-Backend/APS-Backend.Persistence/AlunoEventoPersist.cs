using APS_Backend.Domain;
using APS_Backend.Persistence.Context;
using APS_Backend.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace APS_Backend.Persistence
{
    public class AlunoEventoPersist : IAlunoEventoPersist
    {
        private readonly APSBackendDBContext _context;

        public AlunoEventoPersist(APSBackendDBContext context)
        {
            _context = context;
        }

        public async Task<AlunoEvento> GetAlunoEventoByMatriculaAndEventoIdAsync(int matricula, int EventoId)
        {
            IQueryable<AlunoEvento> query = _context.AlunoEventos.AsQueryable();

            query = query.AsNoTracking()
                         .Where(ae => ae.AlunoId == matricula)
                         .Where(ae => ae.EventoId == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<AlunoEvento[]> GetAlunoEventosByEventosIdAsync(int EventoId)
        {
            IQueryable<AlunoEvento> query = _context.AlunoEventos.AsQueryable();

            query = query.AsNoTracking()
                         .Where(ae => ae.EventoId == EventoId);

            return await query.ToArrayAsync();
        }
    }
}

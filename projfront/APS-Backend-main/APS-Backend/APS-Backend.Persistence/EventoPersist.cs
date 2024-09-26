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
    public class EventoPersist : IEventoPersist
    {
        private readonly APSBackendDBContext _context;

        public EventoPersist(APSBackendDBContext context)
        {
            _context = context;
        }

        public async Task<Evento[]> GetAllEventoAsync()
        {
            IQueryable<Evento> query = _context.Eventos.AsQueryable();

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByAlunoIdAsync(int matricula)
        {
            IQueryable<Evento> query = _context.Eventos.AsQueryable();

            query = query
                .AsNoTracking()
                .OrderBy(e => e.Id)
                .Where(e => _context.AlunoEventos
                    .Any(ae => ae.AlunoId == matricula && ae.EventoId == e.Id)
            );
            
            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosConcluidosByAlunoIdAsync(int matricula)
        {
            IQueryable<Evento> query = _context.Eventos.AsQueryable();

            query = query
                .AsNoTracking()
                .OrderBy(e => e.Id)
                .Where(e => _context.AlunoEventos
                    .Any(ae => ae.AlunoId == matricula && ae.EventoId == e.Id && ae.Status == StatusAluno.Concluido)
            );

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int EventoId)
        {
            IQueryable<Evento> query = _context.Eventos.AsQueryable();


            query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> GetEventoStatusByIdAsync(int EventoId)
        {
            IQueryable<Evento> query = _context.Eventos.AsQueryable();


            var resultado = query
                .Include(e => e.AlunoEventos)
                .ThenInclude(ae => ae.Aluno)
                .Where(e => e.Id == EventoId)
                .Select(e => new 
                {
                    QtdAlunos = e.AlunoEventos.Count,
                    e.QtdMaximaParticipantes
                })
                .FirstOrDefault();


            if (resultado.QtdMaximaParticipantes - resultado.QtdAlunos > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

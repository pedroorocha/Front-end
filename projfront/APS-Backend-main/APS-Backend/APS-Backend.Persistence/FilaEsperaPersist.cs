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
    public class FilaEsperaPersist : IFilaEsperaPersist
    {

        private readonly APSBackendDBContext _context;
        public FilaEsperaPersist(APSBackendDBContext context)
        {
            _context = context;
        }

        public async Task<FilaEspera> GetFilaEsperaByEventoIdAsync(int EventoId)
        {
            IQueryable<FilaEspera> query = _context.FilaEsperas.AsQueryable();

            query = query.Include(fe => fe.Evento)
                         .Where(fe => fe.EventoId == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<FilaEspera> GetFilaEsperaById(int FilaEsperaId)
        {
            IQueryable<FilaEspera> query = _context.FilaEsperas.AsQueryable();

            query = query.AsNoTracking().OrderBy(fe => fe.Id)
                         .Where(fe => fe.Id == FilaEsperaId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> GetFilaEsperaStatusById(int FilaEsperaId)
        {
            IQueryable<FilaEspera> query = _context.FilaEsperas.AsQueryable();


            var resultado = query
                .Include(fe => fe.AlunoEsperas)
                .ThenInclude(ae => ae.Aluno)
                .Where(fe => fe.Id == FilaEsperaId)
                .Select(fe => new
                {
                    QtdAlunos = fe.AlunoEsperas.Count,
                    fe.QtdVagas
                })
                .FirstOrDefault();



            if (resultado.QtdVagas - resultado.QtdAlunos > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<AlunoEspera> GetFirstOnFilaEsperaAsync(int FilaEsperaId)
        {
            IQueryable<FilaEspera> query = _context.FilaEsperas.AsQueryable();

            var resultado = query
                .Include(fe => fe.AlunoEsperas)  
                .ThenInclude(ae => ae.Aluno)    
                .Where(fe => fe.Id == FilaEsperaId)  
                .SelectMany(fe => fe.AlunoEsperas)  
                .OrderBy(ae => ae.DataInscricao)            
                .ThenBy(ae => ae.HoraInscricao);

            return await resultado.FirstOrDefaultAsync();
        }
    }
}

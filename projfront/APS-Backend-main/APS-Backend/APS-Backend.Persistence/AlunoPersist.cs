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

namespace APS_Backend.Persistence
{
    public class AlunoPersist : IAlunoPersist
    {
        private readonly APSBackendDBContext _context;

        public AlunoPersist(APSBackendDBContext context)
        {
            _context = context;
        }

        public async Task<Aluno[]> GetAllAlunosAsync()
        {
            IQueryable<Aluno> query = _context.Alunos.AsQueryable();

            query = query.AsNoTracking().OrderBy(a => a.Matricula);

            return await query.ToArrayAsync();

        }

        public async Task<Aluno[]> GetAllAlunosByCursoAsync(string curso)
        {
            IQueryable<Aluno> query = _context.Alunos.AsQueryable();

            query = query.AsNoTracking().OrderBy(a => a.Matricula)
                         .Where(a => a.Curso == curso);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoByMatriculaAsync(int matricula)
        {
            IQueryable<Aluno> query = _context.Alunos.AsQueryable();

            query = query.AsNoTracking().OrderBy(a => a.Matricula)
                         .Where(a => a.Matricula == matricula);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Aluno[]> GetAllAlunosByEventoIdAsync(int EventoId)
        {
            IQueryable<Aluno> query = _context.Alunos.AsQueryable();

            query = query.Where(aluno =>
                _context.AlunoEventos
                    .Any(ae => ae.EventoId == EventoId && ae.AlunoId == aluno.Matricula)
            );

            return await query.ToArrayAsync();
        }

        public async Task<Aluno[]> GetAlunosEsperaByEventoIdAsync(int EventoId)
        {
            IQueryable<Aluno> query = _context.Alunos.AsQueryable();

            query = query.Where(aluno =>
                _context.AlunoEsperas
                    .Any(ae => ae.FilaEspera.EventoId == EventoId && ae.AlunoId == aluno.Matricula)
            );

            return await query.ToArrayAsync();
        }
    }
}

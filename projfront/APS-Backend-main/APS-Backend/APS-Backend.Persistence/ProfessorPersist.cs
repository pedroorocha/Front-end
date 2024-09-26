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
    public class ProfessorPersist : IProfessorPersist
    {
        private readonly APSBackendDBContext _context;

        public ProfessorPersist(APSBackendDBContext context)
        {
            _context = context;
        }

        public async Task<Professor[]> GetAllProfessorAsync()
        {
            IQueryable<Professor> query = _context.Professors.AsQueryable();

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();

        }

        public async Task<Professor> GetProfessorByIdAsync(int ProfessorId)
        {
            IQueryable<Professor> query = _context.Professors.AsQueryable();

            query = query.AsNoTracking().OrderBy(p => p.Id)
                         .Where(p => p.Id == ProfessorId);

            return await query.FirstOrDefaultAsync();
        }
    }
}

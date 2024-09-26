using APS_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Persistence.Interfaces
{
    public interface IProfessorPersist
    {
        Task<Professor[]> GetAllProfessorAsync();
        Task<Professor> GetProfessorByIdAsync(int ProfessorId);
    }
}

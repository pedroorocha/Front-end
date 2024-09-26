using APS_Backend.Application.Dtos.Aluno;
using APS_Backend.Application.Dtos.Professor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Application.Intefaces
{
    public interface IProfessorService
    {
        Task<ProfessorDto> AddProfessor(CreateProfessorRequestDto model);
        Task<ProfessorDto> UpdateProfessor(int Id, UpdateProfessorRequestDto model);
        Task<bool> DeleteProfessor(int Id);

        Task<ProfessorDto[]> GetAllProfessorAsync();
        Task<ProfessorDto> GetProfessorByIdAsync(int ProfessorId);
    }
}

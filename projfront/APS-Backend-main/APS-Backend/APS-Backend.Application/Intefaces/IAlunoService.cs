using APS_Backend.Application.Dtos.Aluno;
using APS_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Application.Intefaces
{
    public interface IAlunoService
    {
        Task<AlunoDto> AddAluno(CreateAlunoRequestDto model);
        Task<AlunoDto> UpdateAluno(int matricula, UpdateAlunoRequestDto model);
        Task<bool> DeleteAluno(int matricula);

        Task<AlunoDto[]> GetAllAlunosAsync();
        Task<AlunoDto> GetAlunoByIdAsync(int matricula);
        Task<AlunoDto[]> GetAllAlunosByCursoAsync(string curso);
        Task<AlunoDto> GetAlunoByMatriculaAsync(int Matricula);
        Task<AlunoDto[]> GetAllAlunosByEventoIdAsync(int EventoId);
        Task<AlunoDto[]> GetAlunosEsperaByEventoIdAsync(int EventoId);
    }
}

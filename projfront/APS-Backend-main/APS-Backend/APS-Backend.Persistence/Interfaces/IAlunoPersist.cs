using APS_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Persistence.Interfaces
{
    public interface IAlunoPersist
    {
        //Alunos
        Task<Aluno[]> GetAllAlunosAsync();
        Task<Aluno[]> GetAllAlunosByCursoAsync(string curso);
        Task<Aluno> GetAlunoByMatriculaAsync(int Matricula);
        Task<Aluno[]> GetAllAlunosByEventoIdAsync(int EventoId);
        Task<Aluno[]> GetAlunosEsperaByEventoIdAsync(int EventoId);
    }
}

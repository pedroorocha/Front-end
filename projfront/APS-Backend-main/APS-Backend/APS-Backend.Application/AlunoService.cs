using APS_Backend.Application.Dtos.Aluno;
using APS_Backend.Application.Intefaces;
using APS_Backend.Application.Mappers;
using APS_Backend.Domain;
using APS_Backend.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace APS_Backend.Application
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoPersist _alunoPersist;
        private readonly IGeneralPersist _generalPersist;

        //private readonly IMapper _mapper;

        public AlunoService(IAlunoPersist alunoPersist,
                            IGeneralPersist generalPersist)
        {
            _generalPersist = generalPersist;
            _alunoPersist = alunoPersist;
        }

        public async Task<AlunoDto> AddAluno(CreateAlunoRequestDto model)
        {
            try
            {
                var _aluno = model.ToAlunoFromCreateDto();

                _generalPersist.Add<Aluno>(_aluno);

                if (await _generalPersist.SaveChangesAsync())
                {
                    var result = await _alunoPersist.GetAlunoByMatriculaAsync(_aluno.Matricula);
                    return result.ToAlunoDto();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAluno(int matricula)
        {
            try
            {
                var _aluno = await _alunoPersist.GetAlunoByMatriculaAsync(matricula);

                if (_aluno == null)
                {
                    throw new Exception("Event not found.");
                }

                _generalPersist.Delete<Aluno>(_aluno);
                return await _generalPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AlunoDto[]> GetAllAlunosAsync()
        {
            try
            {
                var _alunos = await _alunoPersist.GetAllAlunosAsync();
                if (_alunos == null)
                {
                    return null;
                }

                var results = _alunos.Select(s => s.ToAlunoDto()).ToArray();

                return results;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AlunoDto[]> GetAllAlunosByCursoAsync(string curso)
        {
            try
            {
                var _alunos = await _alunoPersist.GetAllAlunosByCursoAsync(curso);
                if (_alunos == null)
                {
                    return null;
                }

                var results = _alunos.Select(s => s.ToAlunoDto()).ToArray();

                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<AlunoDto[]> GetAllAlunosByEventoIdAsync(int eventoId)
        {
            try
            {
                var _alunos = await _alunoPersist.GetAllAlunosByEventoIdAsync(eventoId);
                if (_alunos == null)
                {
                    return null;
                }

                var results = _alunos.Select(s => s.ToAlunoDto()).ToArray();

                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<AlunoDto> GetAlunoByIdAsync(int matricula)
        {
            try
            {
                var _aluno = await _alunoPersist.GetAlunoByMatriculaAsync(matricula);
                if (_aluno == null)
                {
                    return null;
                }

                var results = _aluno.ToAlunoDto();

                return results;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AlunoDto> GetAlunoByMatriculaAsync(int matricula)
        {
            try
            {
                var _aluno = await _alunoPersist.GetAlunoByMatriculaAsync(matricula);
                if (_aluno == null)
                {
                    return null;
                }

                var result = _aluno.ToAlunoDto();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AlunoDto[]> GetAlunosEsperaByEventoIdAsync(int eventoId)
        {
            try
            {
                var _alunos = await _alunoPersist.GetAlunosEsperaByEventoIdAsync(eventoId);
                if (_alunos == null)
                {
                    return null;
                }

                var results = _alunos.Select(s => s.ToAlunoDto()).ToArray();

                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AlunoDto> UpdateAluno(int matricula, UpdateAlunoRequestDto model)
        {
            try
            {
                var _aluno = await _alunoPersist.GetAlunoByMatriculaAsync(matricula);

                if (_aluno == null)
                {
                    return null;
                }

                _aluno.Email = model.Email;
                _aluno.Senha = model.Senha;
                _aluno.Nome = model.Nome;
                _aluno.CPF = model.CPF;
                _aluno.Curso = model.Curso;
                _aluno.DataDeNascimento = DateOnly.ParseExact(model.DataDeNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                _aluno.Telefone = model.Telefone;


                _generalPersist.Update<Aluno>(_aluno);

                if (await _generalPersist.SaveChangesAsync())
                {
                    var result = await _alunoPersist.GetAlunoByMatriculaAsync(_aluno.Matricula);
                    return result.ToAlunoDto();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

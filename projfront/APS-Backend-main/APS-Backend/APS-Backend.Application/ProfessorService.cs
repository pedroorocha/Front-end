using APS_Backend.Application.Dtos.Professor;
using APS_Backend.Application.Intefaces;
using APS_Backend.Application.Mappers;
using APS_Backend.Domain;
using APS_Backend.Persistence;
using APS_Backend.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Application
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorPersist _professorPersist;
        private readonly IGeneralPersist _generalPersist;

        public ProfessorService(IProfessorPersist professorPersist, IGeneralPersist generalPersist)
        {
            _generalPersist = generalPersist;
            _professorPersist = professorPersist;
        }

        public async Task<ProfessorDto> AddProfessor(CreateProfessorRequestDto model)
        {
            try
            {
                var _professor = model.ToProfessorFromCreateDto();

                _generalPersist.Add<Professor>(_professor);

                if (await _generalPersist.SaveChangesAsync())
                {
                    var result = await _professorPersist.GetProfessorByIdAsync(_professor.Id);
                    return result.ToProfessorDto();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool>DeleteProfessor(int Id)
        {
            try
            {
                var _professor = await _professorPersist.GetProfessorByIdAsync(Id);

                if (_professor == null)
                {
                    throw new Exception("Event not found.");
                }

                _generalPersist.Delete<Professor>(_professor);
                return await _generalPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProfessorDto[]> GetAllProfessorAsync()
        {
            try
            {
                var _professor = await _professorPersist.GetAllProfessorAsync();
                if (_professor == null)
                {
                    return null;
                }

                var results = _professor.Select(s => s.ToProfessorDto()).ToArray();

                return results;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProfessorDto> GetProfessorByIdAsync(int Id)
        {
            try
            {
                var _professor = await _professorPersist.GetProfessorByIdAsync(Id);
                if (_professor == null)
                {
                    return null;
                }

                var results = _professor.ToProfessorDto();

                return results;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProfessorDto> UpdateProfessor(int Id, UpdateProfessorRequestDto model)
        {
            try
            {
                var _professor = await _professorPersist.GetProfessorByIdAsync(Id);

                if (_professor == null)
                {
                    return null;
                }

                _professor.Email = model.Email;
                _professor.Senha = model.Senha;
                _professor.Nome = model.Nome;
                _professor.CPF = model.CPF;
                _professor.Curso = model.Curso;
                _professor.Nascimento = DateOnly.ParseExact(model.Nascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                _professor.Telefone = model.Telefone;


                _generalPersist.Update<Professor>(_professor);

                if (await _generalPersist.SaveChangesAsync())
                {
                    var result = await _professorPersist.GetProfessorByIdAsync(_professor.Id);
                    return result.ToProfessorDto();
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

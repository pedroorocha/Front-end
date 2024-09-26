using APS_Backend.Application.Dtos.Aluno;
using APS_Backend.Application.Dtos.Professor;
using APS_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Application.Mappers
{
    public static class ProfessorMappers
    {
        public static ProfessorDto ToProfessorDto(this Professor professorModel)
        {
            return new ProfessorDto
            {
                Id = professorModel.Id,
                Email = professorModel.Email,
                Nome = professorModel.Nome,
                CPF = professorModel.CPF,
                Curso = professorModel.Curso,
                Nascimento = professorModel.Nascimento.ToString(),
                Telefone = professorModel.Telefone,
            };
        }
        public static Professor ToProfessorFromCreateDto(this CreateProfessorRequestDto professorDto)
        {
            return new Professor
            {
                Id = professorDto.Id,
                Email = professorDto.Email,
                Senha = professorDto.Senha,
                Nome = professorDto.Nome,
                CPF = professorDto.CPF,
                Curso = professorDto.Curso,
                Nascimento = DateOnly.ParseExact(professorDto.Nascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Telefone = professorDto.Telefone,
            };
        }
    }
}

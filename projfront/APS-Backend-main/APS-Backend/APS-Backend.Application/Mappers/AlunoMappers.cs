using APS_Backend.Application.Dtos.Aluno;
using APS_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Application.Mappers
{
    public static class AlunoMappers
    {
        public static AlunoDto ToAlunoDto(this Aluno alunoModel)
        {
            return new AlunoDto
            {
                Matricula = alunoModel.Matricula,
                Email = alunoModel.Email,
                Nome = alunoModel.Nome,
                CPF = alunoModel.CPF,
                Curso = alunoModel.Curso,
                DataDeNascimento = alunoModel.DataDeNascimento.ToString(),
                Telefone = alunoModel.Telefone,
                HorasComplementaresA = alunoModel.HorasComplementaresA,
                HorasComplementaresB = alunoModel.HorasComplementaresB,
                HorasComplementaresC = alunoModel.HorasComplementaresC,
                HorasComplementaresD = alunoModel.HorasComplementaresD,
                HorasComplementaresE = alunoModel.HorasComplementaresE,
                HorasComplementaresF = alunoModel.HorasComplementaresF,
            };
        }

        public static Aluno ToAlunoFromCreateDto(this CreateAlunoRequestDto alunoDto)
        {
            return new Aluno
            {
                Matricula = alunoDto.Matricula,
                Email = alunoDto.Email,
                Senha = alunoDto.Senha,
                Nome = alunoDto.Nome,
                CPF = alunoDto.CPF,
                Curso = alunoDto.Curso,
                DataDeNascimento = DateOnly.ParseExact(alunoDto.DataDeNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Telefone = alunoDto.Telefone,
                HorasComplementaresA = 0,
                HorasComplementaresB = 0,
                HorasComplementaresC = 0,
                HorasComplementaresD = 0,
                HorasComplementaresE = 0,
                HorasComplementaresF = 0,
            };
        }
    }
}

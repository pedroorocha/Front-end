using APS_Backend.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Application.Dtos.Aluno
{
    public class AlunoDto
    {
        public int Matricula { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Curso { get; set; } = string.Empty;
        public string DataDeNascimento { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public int HorasComplementaresA { get; set; }
        public int HorasComplementaresB { get; set; }
        public int HorasComplementaresC { get; set; }
        public int HorasComplementaresD { get; set; }
        public int HorasComplementaresE { get; set; }
        public int HorasComplementaresF { get; set; }

    }
}

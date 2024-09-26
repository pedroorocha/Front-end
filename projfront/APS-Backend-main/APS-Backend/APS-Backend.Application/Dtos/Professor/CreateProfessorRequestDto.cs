using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Application.Dtos.Professor
{
    public class CreateProfessorRequestDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Curso { get; set; } = string.Empty;
        public string Nascimento { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
    }
}

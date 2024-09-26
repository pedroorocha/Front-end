using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APS_Backend.Domain
{
    public class Aluno
    {
        [Key]
        public int Matricula { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Curso { get; set; } = string.Empty;
        public DateOnly DataDeNascimento { get; set; } 
        public string Telefone { get; set; } = string.Empty;

        public int HorasComplementaresA { get; set; }
        public int HorasComplementaresB { get; set; }
        public int HorasComplementaresC { get; set; }
        public int HorasComplementaresD { get; set; }
        public int HorasComplementaresE { get; set; }
        public int HorasComplementaresF { get; set; }

        public List<AlunoEvento> AlunoEventos { get; set; } = new List<AlunoEvento>();
        public List<AlunoEspera> AlunoEsperas { get; set; } = new List<AlunoEspera>();

    }
}

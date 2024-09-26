using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Domain
{
    public class FilaEspera
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; }
        public int? EventoId { get; set; }
        public Evento? Evento { get; set; }

        public List<AlunoEspera> AlunoEsperas { get; set; } = new List<AlunoEspera>();
        public int QtdVagas { get; set; }
    }
}

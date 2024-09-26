using APS_Backend.Application.Dtos.Aluno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Application.Intefaces
{
    public interface IPresencaService
    {
        Task<bool> UpdatePresenca(int EventoId, int[] ListaAlunos);
    }
}

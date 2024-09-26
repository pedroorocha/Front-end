using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Application.Intefaces
{
    public interface ICadastroService
    {
        Task<bool> SubscribeAluno(int matricula, int eventoId);
        Task<bool> UnsubscribeAluno(int matricula, int eventoId);
    }
}

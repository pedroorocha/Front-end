using APS_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Persistence.Interfaces
{
    public interface IEventoPersist
    {
        Task<Evento[]> GetAllEventoAsync();
        Task<Evento[]> GetAllEventosByAlunoIdAsync(int matricula);
        Task<Evento[]> GetAllEventosConcluidosByAlunoIdAsync(int matricula);
        Task<Evento> GetEventoByIdAsync(int EventoId);
        Task<bool> GetEventoStatusByIdAsync(int EventoId);

    }
}

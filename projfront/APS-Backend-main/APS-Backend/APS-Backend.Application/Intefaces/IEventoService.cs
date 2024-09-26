using APS_Backend.Application.Dtos.Evento;
using APS_Backend.Application.Dtos.Professor;
using APS_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Application.Intefaces
{
    public interface IEventoService
    {
        Task<EventoDto> AddEvento(CreateEventoRequestDto model);
        Task<EventoDto> UpdateEvento(int Id, UpdateEventoRequestDto model);
        Task<bool> DeleteEvento(int Id);

        Task<EventoDto[]> GetAllEventoAsync();
        Task<EventoDto> GetEventoByIdAsync(int IdEventoId);
        Task<EventoDto[]> GetAllEventosByAlunoIdAsync(int matricula);
        Task<EventoDto[]> GetAllEventosConcluidosByAlunoIdAsync(int matricula);
        Task<bool> GetEventoStatusByIdAsync(int EventoId);
    }
}

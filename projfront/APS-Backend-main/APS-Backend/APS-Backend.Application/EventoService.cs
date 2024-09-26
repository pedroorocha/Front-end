using APS_Backend.Application.Dtos.Aluno;
using APS_Backend.Application.Dtos.Evento;
using APS_Backend.Application.Intefaces;
using APS_Backend.Application.Mappers;
using APS_Backend.Domain;
using APS_Backend.Persistence;
using APS_Backend.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Application
{
    public class EventoService : IEventoService
    {
        private readonly IEventoPersist _eventoPersist;
        private readonly IGeneralPersist _generalPersist;

        public EventoService(IEventoPersist eventoPersist, IGeneralPersist generalPersist)
        {
            _generalPersist = generalPersist;
            _eventoPersist = eventoPersist;
        }

        public async Task<EventoDto> AddEvento(CreateEventoRequestDto model)
        {
            try
            {
                var _evento = model.ToEventoFromCreateDto();

                _generalPersist.Add<Evento>(_evento);

                if (await _generalPersist.SaveChangesAsync())
                {
                    var result = await _eventoPersist.GetEventoByIdAsync(_evento.Id);
                    return result.ToEventoDto();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEvento(int Id)
        {
            try
            {
                var _evento = await _eventoPersist.GetEventoByIdAsync(Id);

                if (_evento == null)
                {
                    throw new Exception("Event not found.");
                }

                _generalPersist.Delete<Evento>(_evento);
                return await _generalPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<EventoDto[]> GetAllEventoAsync()
        {
            try
            {
                var _evento = await _eventoPersist.GetAllEventoAsync();
                if (_evento == null)
                {
                    return null;
                }

                var results = _evento.Select(s => s.ToEventoDto()).ToArray();

                return results;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosByAlunoIdAsync(int matricula)
        {
            try
            {
                var _evento = await _eventoPersist.GetAllEventosByAlunoIdAsync(matricula);
                if (_evento == null)
                {
                    return null;
                }

                var results = _evento.Select(s => s.ToEventoDto()).ToArray();

                return results;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosConcluidosByAlunoIdAsync(int matricula)
        {
            try
            {
                var _eventos = await _eventoPersist.GetAllEventosConcluidosByAlunoIdAsync(matricula);
                if (_eventos == null)
                {
                    return null;
                }

                var results = _eventos.Select(e => e.ToEventoDto()).ToArray();

                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<EventoDto>GetEventoByIdAsync(int Id)
        {
            try
            {
                var _evento = await _eventoPersist.GetEventoByIdAsync(Id);
                if (_evento == null)
                {
                    return null;
                }

                var results = _evento.ToEventoDto();

                return results;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> GetEventoStatusByIdAsync(int EventoId)
        {
            throw new NotImplementedException();
        }

        public async Task<EventoDto> UpdateEvento(int Id, UpdateEventoRequestDto model)
        {
            try
            {
                var _evento = await _eventoPersist.GetEventoByIdAsync(Id);

                if (_evento == null)
                {
                    return null;
                }

                _evento.Nome = model.Nome;
                _evento.Categoria = model.Categoria;
                _evento.Tema = model.Tema;
                _evento.Data = DateOnly.ParseExact(model.Data, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                _evento.Hora = TimeOnly.ParseExact(model.Hora, "HH:mm", CultureInfo.InvariantCulture);
                _evento.HorasComplementares = model.HorasComplementares;
                _evento.QtdMaximaParticipantes = model.QtdMaximaParticipantes;
                _evento.Palestrantes = model.Palestrantes;
                _evento.Descricao = model.Descricao;


                _generalPersist.Update<Evento>(_evento);

                if (await _generalPersist.SaveChangesAsync())
                {
                    var result = await _eventoPersist.GetEventoByIdAsync(_evento.Id);
                    return result.ToEventoDto();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

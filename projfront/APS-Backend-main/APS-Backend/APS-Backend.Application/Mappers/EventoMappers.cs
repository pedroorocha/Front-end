using APS_Backend.Application.Dtos.Aluno;
using APS_Backend.Application.Dtos.Evento;
using APS_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Application.Mappers
{
    public static class EventoMappers
    {
        public static EventoDto ToEventoDto(this Evento eventoModel)
        {
            return new EventoDto
            {
                Id = eventoModel.Id,
                Nome = eventoModel.Nome,
                Categoria = eventoModel.Categoria,
                Tema = eventoModel.Tema,
                Data = eventoModel.Data.ToString(),
                Hora = eventoModel.Hora.ToString(),
                HorasComplementares = eventoModel.HorasComplementares.ToString(),
                QtdMaximaParticipantes = eventoModel.QtdMaximaParticipantes,
                Palestrantes = eventoModel.Palestrantes,
                Descricao = eventoModel.Descricao,
            };
        }
        public static Evento ToEventoFromCreateDto(this CreateEventoRequestDto eventoDto)
        {
            return new Evento
            {
                Nome = eventoDto.Nome,
                Categoria = eventoDto.Categoria,
                Tema = eventoDto.Tema,
                Data = DateOnly.ParseExact(eventoDto.Data, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Hora = TimeOnly.ParseExact(eventoDto.Hora, "HH:mm", CultureInfo.InvariantCulture),
                HorasComplementares = eventoDto.HorasComplementares,
                QtdMaximaParticipantes = eventoDto.QtdMaximaParticipantes,
                Palestrantes = eventoDto.Palestrantes,
                Descricao = eventoDto.Descricao,
            };
        }
    }
}

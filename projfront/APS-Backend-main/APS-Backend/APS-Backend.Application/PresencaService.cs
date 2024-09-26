using APS_Backend.Application.Dtos.Aluno;
using APS_Backend.Application.Intefaces;
using APS_Backend.Domain;
using APS_Backend.Persistence;
using APS_Backend.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Application
{
    public class PresencaService : IPresencaService
    {
        private readonly IGeneralPersist _generalPersist;
        private readonly IEventoPersist _eventoPersist;
        private readonly IAlunoPersist _alunoPersist;
        private readonly IAlunoEventoPersist _alunoEventoPersist;

        public PresencaService(IGeneralPersist generalPersist, 
                               IEventoPersist eventoPersist, 
                               IAlunoPersist alunoPersist,
                               IAlunoEventoPersist alunoEventoPersist)
        {
            _generalPersist = generalPersist;
            _eventoPersist = eventoPersist;
            _alunoPersist = alunoPersist;
            _alunoEventoPersist = alunoEventoPersist;
        }

        public async Task<bool> UpdatePresenca(int EventoId, int[] ListaAlunos)
        {
            // Verifica se o curso ainda está ativo
            var dataAtual = DateOnly.FromDateTime(DateTime.Now);
            var horaAtual = TimeOnly.FromDateTime(DateTime.Now);

            var _evento = await _eventoPersist.GetEventoByIdAsync(EventoId);

            if (dataAtual > _evento.Data)
            {
                return false;
            }

            // Busca alunos inscritos no evento
            var _listaAlunosEventos = await _alunoEventoPersist.GetAlunoEventosByEventosIdAsync(EventoId);

            foreach (var alunoEvento in _listaAlunosEventos)
            {
                // Verifica se o AlunoId (Matricula) está na lista de alunos
                if (ListaAlunos.Contains(alunoEvento.AlunoId))
                {
                    // Atualiza a propriedade Status para 4
                    alunoEvento.Status = StatusAluno.Concluido;

                    _generalPersist.Update<AlunoEvento>(alunoEvento);

                    var _aluno = await _alunoPersist.GetAlunoByMatriculaAsync(alunoEvento.AlunoId);

                    await UpdateHorasComplementares(_aluno, 
                                              _evento.Categoria, 
                                              _evento.HorasComplementares);

                }
            }

            await _generalPersist.SaveChangesAsync();

            return true;

        }

        public async Task<bool> UpdateHorasComplementares(Aluno Aluno, string TipoHoras, int qtdHoras)
        {
            if (TipoHoras == "A")
            {
                Aluno.HorasComplementaresA += qtdHoras;
                
            }
            else if (TipoHoras == "B")
            {
                Aluno.HorasComplementaresB += qtdHoras;
            }
            else if (TipoHoras == "C")
            {
                Aluno.HorasComplementaresC += qtdHoras;
            }
            else if (TipoHoras == "D")
            {
                Aluno.HorasComplementaresD += qtdHoras;
            }
            else if (TipoHoras == "E")
            {
                Aluno.HorasComplementaresE += qtdHoras;
            }
            else if (TipoHoras == "F")
            {
                Aluno.HorasComplementaresF += qtdHoras;
            }

            else
            {
                return false;
            }

            _generalPersist.Update<Aluno>(Aluno);

            await _generalPersist.SaveChangesAsync();

            return true;
        }
    }
}

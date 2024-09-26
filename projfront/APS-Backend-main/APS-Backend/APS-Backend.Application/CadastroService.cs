using APS_Backend.Application.Intefaces;
using APS_Backend.Domain;
using APS_Backend.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Application
{
    public class CadastroService : ICadastroService
    {
        private readonly IGeneralPersist _generalPersist;
        private readonly IEventoPersist _eventoPersist;
        private readonly IFilaEsperaPersist _filaEsperaPersist;
        private readonly IAlunoEventoPersist _alunoEventoPersist;
        private readonly IAlunoEsperaPersist _alunoEsperaPersist;

        public CadastroService(IGeneralPersist generalPersist, 
                               IEventoPersist eventoPersist, 
                               IFilaEsperaPersist filaEsperaPersist,
                               IAlunoEventoPersist alunoEventoPersist,
                               IAlunoEsperaPersist alunoEsperaPersist)
        {
            _generalPersist = generalPersist;
            _eventoPersist = eventoPersist;
            _filaEsperaPersist = filaEsperaPersist;
            _alunoEventoPersist = alunoEventoPersist;
            _alunoEsperaPersist = alunoEsperaPersist;
        }

        public async Task<bool> SubscribeAluno(int matricula, int eventoId)
        {
            try
            {   
                // Verifica se o aluno já está inscrito, se sim, retorna falso.

                var _alreadyReg = await _alunoEventoPersist.GetAlunoEventoByMatriculaAndEventoIdAsync(matricula, eventoId);

                if (_alreadyReg != null)
                {
                    return false;
                }


                // Verifica as vagas no evento
                bool vagas = await _eventoPersist.GetEventoStatusByIdAsync(eventoId);

                // Se tiver vagas
                if (vagas) 
                {
                    // Adiciona o aluno ao evento

                    var _alunoEvento = new AlunoEvento { AlunoId = matricula, EventoId = eventoId };

                    _generalPersist.Add<AlunoEvento>(_alunoEvento);

                    if (await _generalPersist.SaveChangesAsync())
                    {
                        return true;
                    }
                }
                // Se não tiver vagas
                else
                {
                    // Verifica se existe uma fila de espera para adicionar o aluno
                    var _filaEspera = await _filaEsperaPersist.GetFilaEsperaByEventoIdAsync(eventoId);

                    // Se não tiver fila de espera
                    if (_filaEspera == null)
                    {

                        // Cria fila de espera para o evento
                        var _newFilaEspera = new FilaEspera { EventoId = eventoId, QtdVagas = 100 };

                        _generalPersist.Add<FilaEspera>(_newFilaEspera);

                        await _generalPersist.SaveChangesAsync();

                        // Adiciona o aluno na fila de espera criada
                        
                        var result = await _filaEsperaPersist.GetFilaEsperaByEventoIdAsync(eventoId);

                        var _alunoEspera = new AlunoEspera { 
                                                AlunoId = matricula, 
                                                FilaEsperaId = result.Id,
                                                DataInscricao = DateOnly.FromDateTime(DateTime.Now),
                                                HoraInscricao = TimeOnly.FromDateTime(DateTime.Now)
                        };

                        _generalPersist.Add<AlunoEspera>(_alunoEspera);

                        await _generalPersist.SaveChangesAsync();

                        return true;

                    }
                    // Se já tiver fila de espera
                    else
                    {
                        // Adiciona o aluno na fila de espera já existente

                        var _alunoEspera = new AlunoEspera { 
                                                AlunoId = matricula, 
                                                FilaEsperaId = _filaEspera.Id,
                                                DataInscricao = DateOnly.FromDateTime(DateTime.Now),
                                                HoraInscricao = TimeOnly.FromDateTime(DateTime.Now)
                        };

                        _generalPersist.Add<AlunoEspera>(_alunoEspera);

                        await _generalPersist.SaveChangesAsync();

                        return true;
                    }
                }

                return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UnsubscribeAluno(int matricula, int eventoId)
        {
            try
            {
                // Procura o aluno em AlunoEvento
                var _alunoEvento = await _alunoEventoPersist.GetAlunoEventoByMatriculaAndEventoIdAsync(matricula, eventoId);


                // Se não existir em AlunoEvento
                if (_alunoEvento == null)
                {
                    // Procura o aluno em AlunoEspera
                    var _alunoEspera = await _alunoEsperaPersist.GetAlunoEsperaByMatriculaAndEventoIdAsync(matricula, eventoId);
                    
                    // Se não existir, então o aluno não está cadastrado no evento
                    if (_alunoEspera == null)
                    {
                        return false;   
                    }

                    // Se existir na fila de espera, ele é retirado
                    _generalPersist.Delete<AlunoEspera>(_alunoEspera);

                    await _generalPersist.SaveChangesAsync();

                    return true;
                }
                // Se existir em AlunoEvento
                else
                {
                    // Remove ele de aluno evento
                    _generalPersist.Delete<AlunoEvento>(_alunoEvento);

                    await _generalPersist.SaveChangesAsync();

                    // Busca a fila de espera do evento

                    var _filaEspera = await _filaEsperaPersist.GetFilaEsperaByEventoIdAsync(eventoId);

                    if (_filaEspera == null)
                    {
                        return true;
                    }

                    // Pega o primeiro da fila de espera do evento

                    var _auxAlunoEspera = await _filaEsperaPersist.GetFirstOnFilaEsperaAsync(_filaEspera.Id);

                    var _newAlunoEvento = new AlunoEvento { AlunoId = _auxAlunoEspera.AlunoId, EventoId = eventoId };

                    // Adiciona o primeiro da fila de espera no evento
                    _generalPersist.Add<AlunoEvento>(_newAlunoEvento);

                    await _generalPersist.SaveChangesAsync();

                    // Exclui ele da fila de espera
                    _generalPersist.Delete<AlunoEspera>(_auxAlunoEspera);

                    await _generalPersist.SaveChangesAsync();


                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

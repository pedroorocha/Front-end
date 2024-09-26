using APS_Backend.Domain;
using APS_Backend.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Persistence.Interfaces
{
    public interface IFilaEsperaPersist
    {
        Task<FilaEspera> GetFilaEsperaByEventoIdAsync(int EventoId);
        Task<FilaEspera> GetFilaEsperaById(int FilaEsperaId);
        Task<bool> GetFilaEsperaStatusById(int FilaEsperaId);
        Task<AlunoEspera> GetFirstOnFilaEsperaAsync(int FilaEsperaId);
    }
}

using APS_Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Backend.Persistence.Context
{
    public class APSBackendDBContext : DbContext
    {
        //public APSBackendDBContext(DbContextOptions dbContextOptions): base(dbContextOptions) { }
        public APSBackendDBContext(DbContextOptions<APSBackendDBContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }  

        public DbSet<AlunoEvento> AlunoEventos { get; set; }
        //as
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<FilaEspera> FilaEsperas { get; set; }
        public DbSet<AlunoEspera> AlunoEsperas { get; set; }
        public DbSet<Professor> Professors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoEvento>()
            .HasKey(AE => new { AE.AlunoId, AE.EventoId });

            modelBuilder.Entity<AlunoEspera>()
            .HasKey(AS => new { AS.AlunoId, AS.FilaEsperaId });

            modelBuilder.Entity<Evento>()
                .HasOne(e => e.FilaEspera)
                .WithOne(fe => fe.Evento)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey<FilaEspera>(e => e.EventoId);

            modelBuilder.Entity<FilaEspera>()
                .HasOne(e => e.Evento)
                .WithOne(fe => fe.FilaEspera)
                .HasForeignKey<Evento>(e => e.FilaEsperaId);

            modelBuilder.Entity<Professor>()
                .HasMany(e => e.Eventos)
                .WithOne(sm => sm.Professor)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

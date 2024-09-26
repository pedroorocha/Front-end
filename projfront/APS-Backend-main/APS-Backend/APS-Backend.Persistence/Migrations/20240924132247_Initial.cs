using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APS_Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Matricula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    Curso = table.Column<string>(type: "TEXT", nullable: false),
                    DataDeNascimento = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    HorasComplementaresA = table.Column<int>(type: "INTEGER", nullable: false),
                    HorasComplementaresB = table.Column<int>(type: "INTEGER", nullable: false),
                    HorasComplementaresC = table.Column<int>(type: "INTEGER", nullable: false),
                    HorasComplementaresD = table.Column<int>(type: "INTEGER", nullable: false),
                    HorasComplementaresE = table.Column<int>(type: "INTEGER", nullable: false),
                    HorasComplementaresF = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Matricula);
                });

            migrationBuilder.CreateTable(
                name: "FilaEsperas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventoId = table.Column<int>(type: "INTEGER", nullable: true),
                    QtdVagas = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilaEsperas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    Curso = table.Column<string>(type: "TEXT", nullable: false),
                    Nascimento = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    IsCoordenador = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunoEsperas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    FilaEsperaId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataInscricao = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    HoraInscricao = table.Column<TimeOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoEsperas", x => new { x.AlunoId, x.FilaEsperaId });
                    table.ForeignKey(
                        name: "FK_AlunoEsperas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoEsperas_FilaEsperas_FilaEsperaId",
                        column: x => x.FilaEsperaId,
                        principalTable: "FilaEsperas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProfessorId = table.Column<int>(type: "INTEGER", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false),
                    Tema = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Hora = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    HorasComplementares = table.Column<int>(type: "INTEGER", nullable: false),
                    QtdMaximaParticipantes = table.Column<int>(type: "INTEGER", nullable: false),
                    Palestrantes = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    FilaEsperaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_FilaEsperas_FilaEsperaId",
                        column: x => x.FilaEsperaId,
                        principalTable: "FilaEsperas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Eventos_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoEventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "INTEGER", nullable: false),
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoEventos", x => new { x.AlunoId, x.EventoId });
                    table.ForeignKey(
                        name: "FK_AlunoEventos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoEventos_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoEsperas_FilaEsperaId",
                table: "AlunoEsperas",
                column: "FilaEsperaId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoEventos_EventoId",
                table: "AlunoEventos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_FilaEsperaId",
                table: "Eventos",
                column: "FilaEsperaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_ProfessorId",
                table: "Eventos",
                column: "ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoEsperas");

            migrationBuilder.DropTable(
                name: "AlunoEventos");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "FilaEsperas");

            migrationBuilder.DropTable(
                name: "Professors");
        }
    }
}

using APS_Backend.Application;
using APS_Backend.Application.Intefaces;
using APS_Backend.Persistence;
using APS_Backend.Persistence.Context;
using APS_Backend.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<APSBackendDBContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IGeneralPersist, GeneralPersist>();
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<IAlunoPersist, AlunoPersist>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<IProfessorPersist, ProfessorPersist>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IEventoPersist, EventoPersist>();
builder.Services.AddScoped<IAlunoEventoPersist, AlunoEventoPersist>();
builder.Services.AddScoped<IAlunoEsperaPersist, AlunoEsperaPersist>();
builder.Services.AddScoped<IFilaEsperaPersist, FilaEsperaPersist>();
builder.Services.AddScoped<ICadastroService, CadastroService>();
builder.Services.AddScoped<IPresencaService, PresencaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("PermitirTudo");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

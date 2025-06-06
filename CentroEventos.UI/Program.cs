using CentroEventos.UI.Components;
using CentroEventos.Aplicacion.UseCases;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;
using CentroEventos.Aplicacion.Service;
using CentroEventos.Aplicacion.UseCases.Evento;
using CentroEventos.Aplicacion.UseCases.Personas;
using CentroEventos.Aplicacion.UseCases.Reservas;
using CentroEventos.Repositorios.Repos;
using CentroEventos.Repositorios.Data;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Repositorios
builder.Services.AddScoped<IRepositorioPersona, RepositorioPersona>();
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReserva>();

// Servicios
builder.Services.AddSingleton<IServicioAutorizacion, ServicioAutorizacionProvisorio>();

// Validadores
builder.Services.AddScoped<ValidadorPersona>();
builder.Services.AddScoped<ValidadorEventoDeportivo>();
builder.Services.AddScoped<ValidadorReserva>();

// Casos de uso Personas
builder.Services.AddScoped<AgregarPersonaUseCase>();
builder.Services.AddScoped<ModificarPersonaUseCase>();
builder.Services.AddScoped<ListarPersonasUseCase>();
builder.Services.AddScoped<EliminarPersonaUseCase>();

// Casos de uso Eventos
builder.Services.AddScoped<AgregarEventoDeportivoUseCase>();
builder.Services.AddScoped<ModificarEventoDeportivoUseCase>();
builder.Services.AddScoped<ListarEventosDeportivoUseCase>();
builder.Services.AddScoped<EliminarEventoDeportivoUseCase>();
builder.Services.AddScoped<ListarEventosConCupoDisponibleUseCase>();
builder.Services.AddScoped<ListarAsistenciaAEventoUseCase>();

// Casos de uso Reservas
builder.Services.AddScoped<ReservaAltaUseCase>();
builder.Services.AddScoped<ModificarReservaUseCase>();
builder.Services.AddScoped<ListarReservasUseCase>();
builder.Services.AddScoped<EliminarReservaUseCase>();

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddMudServices();



var app = builder.Build();
CentroEventosSqlite.Inicializar();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();



app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
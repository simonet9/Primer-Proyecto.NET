using CentroEventos.Aplicacion.UseCases;
using Microsoft.Extensions.DependencyInjection;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;
using CentroEventos.Aplicacion.Service;
using CentroEventos.Aplicacion.UseCases;
using CentroEventos.Aplicacion.UseCases.Evento;
using CentroEventos.Aplicacion.UseCases.Personas;
using CentroEventos.Aplicacion.UseCases.Reservas;
using CentroEventos.Repositorios.Repos;

var services = new ServiceCollection();

// Repositorios
services.AddScoped<IRepositorioPersona, RepositorioPersona>();
services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
services.AddScoped<IRepositorioReserva, RepositorioReserva>();

// Servicios
services.AddSingleton<IServicioAutorizacion, ServicioAutorizacionProvisorio>();

// Validadores
services.AddScoped<ValidadorPersona>();
services.AddScoped<ValidadorEventoDeportivo>();
services.AddScoped<ValidadorReserva>();

// Casos de uso Personas
services.AddScoped<AgregarPersonaUseCase>();
services.AddScoped<ModificarPersonaUseCase>();
services.AddScoped<ListarPersonasUseCase>();
services.AddScoped<EliminarPersonaUseCase>();

// Casos de uso Eventos
services.AddScoped<AgregarEventoDeportivoUseCase>();
services.AddScoped<ModificarEventoDeportivoUseCase>();
services.AddScoped<ListarEventosDeportivoUseCase>();
services.AddScoped<EliminarEventoDeportivoUseCase>();
services.AddScoped<ListarEventosConCupoDisponibleUseCase>();
services.AddScoped<ListarAsistenciaAEventoUseCase>();

// Casos de uso Reservas
services.AddScoped<ReservaAltaUseCase>();
services.AddScoped<ModificarReservaUseCase>();
services.AddScoped<ListarReservasUseCase>();
services.AddScoped<EliminarReservaUseCase>();

var provider = services.BuildServiceProvider();
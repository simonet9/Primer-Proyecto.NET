using CentroEventos.UI.Components;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;
using CentroEventos.Aplicacion.Service;
using CentroEventos.Aplicacion.UseCases.Evento;
using CentroEventos.Aplicacion.UseCases.Personas;
using CentroEventos.Aplicacion.UseCases.Reservas;
using CentroEventos.Aplicacion.UseCases.Users;
using CentroEventos.Repositorios.Repos;
using CentroEventos.Repositorios.Data;
using MudBlazor.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Database configuration
// Configura la ruta de la base de datos
var basePath = AppContext.BaseDirectory;
var projectPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
var dataFolder = Path.Combine(projectPath, "Data");
Directory.CreateDirectory(dataFolder);
var dbPath = Path.Combine(dataFolder, "CentroEventos.sqlite");

// Configura el contexto con la cadena de conexión
builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Repositorios
builder.Services.AddScoped<IRepositorioPersona, RepositorioPersona>();
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReserva>();

// Servicios
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();

// Validadores
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
builder.Services.AddMudServices();


// Repositorios de usuarios
builder.Services.AddScoped<RegistrarUsuarioUseCase>();
builder.Services.AddScoped<RegistrarUsuarioUseCase>();
builder.Services.AddScoped<ModificarUsuarioUseCase>();
builder.Services.AddScoped<ListarUsuariosUseCase>();
builder.Services.AddScoped<EliminarUsuarioUseCase>();

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    CentroEventosSqlite.Inicializar(scope.ServiceProvider);
}
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
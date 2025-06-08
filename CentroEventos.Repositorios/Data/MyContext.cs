using CentroEventos.Aplicacion.Entities;
using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios.Data;

public class MyContext : DbContext
{
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    // Obtener carpeta base relativa al lugar donde está ejecutando la app
    var basePath = AppContext.BaseDirectory;
    // Obtener la ruta del proyecto
    var projectPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(basePath, @"..\..\..\"));
    // Crear carpeta Data dentro del proyecto
    var dataFolder = System.IO.Path.Combine(projectPath, "Data");
    System.IO.Directory.CreateDirectory(dataFolder);
    // Ruta completa para la DB
    var dbPath = System.IO.Path.Combine(dataFolder, "CentroEventos.sqlite");
    optionsBuilder.UseSqlite($"Data Source={dbPath}");
}

}
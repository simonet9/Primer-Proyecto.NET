using CentroEventos.Aplicacion.Entities;
using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios.Data;

public class MyContext(DbContextOptions<MyContext> options) : DbContext(options)
{
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    
}
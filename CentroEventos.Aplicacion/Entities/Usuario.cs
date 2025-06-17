using CentroEventos.Aplicacion.Enum;

namespace CentroEventos.Aplicacion.Entities;

// CentroEventos.Aplicacion/Entities/Usuario.cs
public class Usuario
{
  public Usuario() { } // Constructor sin parámetros para EF Core

  public Usuario(string nombre, string apellido, string email, string hashPassword, List<Permiso> datosPermisos)
  {
    Nombre = nombre;
    Apellido = apellido;
    Email = email;
    HashPassword = hashPassword;
    Permisos = datosPermisos;
  }

  public Guid Id { get; set; } = Guid.NewGuid();
  public string Nombre { get; set; } = string.Empty;
  public string Apellido { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string HashPassword { get; set; } = string.Empty;
  public List<Permiso> Permisos { get; set; } = new();
}
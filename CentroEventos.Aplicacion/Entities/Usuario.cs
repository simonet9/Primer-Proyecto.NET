using CentroEventos.Aplicacion.Enum;

namespace CentroEventos.Aplicacion.Entities;

public class Usuario(string nombre, string apellido, string email, string hashPassword)
{
  
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Nombre { get; set; } = nombre;
  public string Apellido { get; set; } = apellido;
  public string Email { get; set; } = email;
  public string HashPassword { get; set; } = hashPassword;
  public List<Permiso> Permisos { get; set; } = new();
}
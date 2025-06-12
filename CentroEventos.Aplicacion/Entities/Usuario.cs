using CentroEventos.Aplicacion.Enum;

namespace CentroEventos.Aplicacion.Entities;

public class Usuario(string nombre, string apellido, string email, string contrasena)
{
  
  //Cada usuario debe tener nombre, apellido, correo electrónico, contraseña
  //y una lista de permisos.
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Nombre { get; set; } = nombre;
  public string Apellido { get; set; } = apellido;
  public string Email { get; set; } = email;
  public string Contrasena { get; set; } = contrasena;
  public List<Permiso> Permisos { get; set; } = new();
}
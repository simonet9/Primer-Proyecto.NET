
namespace CentroEventos.Aplicacion.Entities;

public class Persona
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Dni { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; }= string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    
    public Persona(string dNi, string nombre, string apellido, string email, string telefono)
    {
        Dni = dNi;
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Telefono = telefono;
    }

    protected Persona() { } // Constructor sin parámetros para EF Core

    public override string ToString()
    {
        return $"Persona [ DNI={Dni}, Nombre={Nombre} {Apellido}, Email={Email}, Telefono={Telefono}]";
    }
}
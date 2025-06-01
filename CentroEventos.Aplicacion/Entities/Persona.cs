
namespace CentroEventos.Aplicacion.Entities;

public class Persona
{
    public Guid Id { get; set; }
    public string DNI { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }

    public Persona(Guid id, string dNI, string nombre, string apellido, string email, string telefono)
    {
        Id = id;
        DNI = dNI;
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Telefono = telefono;
    }

    protected Persona() { } // Constructor sin parámetros para EF Core

    public override string ToString()
    {
        return $"Persona [Id={Id}, DNI={DNI}, Nombre={Nombre} {Apellido}, Email={Email}, Telefono={Telefono}]";
    }
}
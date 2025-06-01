namespace CentroEventos.Aplicacion.Entities;

public class Persona(int id, string dNI, string nombre, string apellido, string email, string telefono)
{
    public int Id { get; set; } = id;
    public string DNI { get; set; } = dNI;
    public string Nombre { get; set; } = nombre;
    public string Apellido { get; set; } = apellido;
    public string Email { get; set; } = email;
    public string Telefono { get; set; } = telefono;

    public override string ToString()
    {
        return $"Persona [Id={Id}, DNI={DNI}, Nombre={Nombre} {Apellido}, Email={Email}, Telefono={Telefono}]";
    }
}
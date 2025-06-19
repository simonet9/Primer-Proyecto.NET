
namespace CentroEventos.Aplicacion.Entities;

public class EventoDeportivo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nombre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime FechaHoraInicio { get; set; } = DateTime.Now;
    public double DurationHoras { get; set; }
    public int CupoMaximo { get; set; }
    public Guid ResponsableId { get; set; } = Guid.Empty;

    public EventoDeportivo(string nombre, string description, DateTime fechaHoraInicio, double durationHoras, int cupoMaximo, Guid responsableId)
    {
        Nombre = nombre;
        Description = description;
        FechaHoraInicio = fechaHoraInicio;
        DurationHoras = durationHoras;
        CupoMaximo = cupoMaximo;
        ResponsableId = responsableId;
    }

    protected EventoDeportivo() { } // Constructor sin parámetros para EF Core

    public override string ToString()
    {
        return $"Evento [Id={Id}, Nombre={Nombre}, FechaHoraInicio={FechaHoraInicio:yyyy-MM-dd HH:mm}, Duracion={DurationHoras}h, CupoMaximo={CupoMaximo}, ResponsableId={ResponsableId}]";
    }
}
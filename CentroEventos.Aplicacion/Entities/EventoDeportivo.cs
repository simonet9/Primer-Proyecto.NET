
namespace CentroEventos.Aplicacion.Entities;

public class EventoDeportivo
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaHoraInicio { get; set; }
    public double DuracionHoras { get; set; }
    public int CupoMaximo { get; set; }
    public Guid ResponsableId { get; set; }

    public EventoDeportivo(Guid id, string nombre, string descripcion, DateTime fechaHoraInicio, double duracionHoras, int cupoMaximo, Guid responsableId)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        FechaHoraInicio = fechaHoraInicio;
        DuracionHoras = duracionHoras;
        CupoMaximo = cupoMaximo;
        ResponsableId = responsableId;
    }

    protected EventoDeportivo() { } // Constructor sin parámetros para EF Core

    public override string ToString()
    {
        return $"Evento [Id={Id}, Nombre={Nombre}, FechaHoraInicio={FechaHoraInicio:yyyy-MM-dd HH:mm}, Duracion={DuracionHoras}h, CupoMaximo={CupoMaximo}, ResponsableId={ResponsableId}]";
    }
}

namespace CentroEventos.Aplicacion.Entities;

public class EventoDeportivo(int id, string nombre, string descripcion, DateTime fechaHoraInicio, double duracionHoras, int cupoMaximo, int responsableId)
{
    public int Id { get; set; } = id;
    public string Nombre { get; set; } = nombre;
    public string Descripcion { get; set; } = descripcion;
    public DateTime FechaHoraInicio { get; set; } = fechaHoraInicio;
    public double DuracionHoras { get; set; } = duracionHoras;
    public int CupoMaximo { get; set; } = cupoMaximo;
    public int ResponsableId { get; set; } = responsableId;

    public override string ToString()
    {
        return $"Evento [Id={Id}, Nombre={Nombre}, FechaHoraInicio={FechaHoraInicio:yyyy-MM-dd HH:mm}, Duracion={DuracionHoras}h, CupoMaximo={CupoMaximo}, ResponsableId={ResponsableId}]";
    }

}
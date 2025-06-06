using CentroEventos.Aplicacion.Enum;

namespace CentroEventos.Aplicacion.Entities;

public class Reserva
{
public Guid Id { get; protected set; } = Guid.NewGuid();
public Guid PersonaId { get; protected set; }
public Guid EventoDeportivoId { get; protected set; }
    public DateTime FechaAltaReserva { get; set; }
    public Estado EstadoAsistencia { get; set; }

    public Reserva(Guid personaId, Guid eventoDeportivoId, DateTime fechaAltaReserva, Estado estadoAsistencia)
    {
        PersonaId = personaId;
        EventoDeportivoId = eventoDeportivoId;
        FechaAltaReserva = fechaAltaReserva;
        EstadoAsistencia = estadoAsistencia;
    }
    protected Reserva() { } // Constructor sin parámetros para EF Core
    public override string ToString()
    {
        return $"Reserva [Id={Id}, PersonaId={PersonaId}, EventoId={EventoDeportivoId}, FechaAlta={FechaAltaReserva:yyyy-MM-dd HH:mm}, Estado={EstadoAsistencia}]";
    }
}
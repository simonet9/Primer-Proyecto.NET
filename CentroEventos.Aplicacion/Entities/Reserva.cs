using CentroEventos.Aplicacion.Enum;

namespace CentroEventos.Aplicacion.Entities;

public class Reserva
{
public Guid Id { get; set; } = Guid.NewGuid();
public Guid PersonaId { get; set; } = Guid.Empty;
public Guid EventoDeportivoId { get; set; } = Guid.Empty;
public DateTime FechaAltaReserva { get; set; } = DateTime.Now;
public Estado EstadoAsistencia { get; set; } = Estado.Pendiente;

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
using CentroEventos.Aplicacion.Enum;

namespace CentroEventos.Aplicacion.Entities;

public class Reserva(int id, int personaId, int eventoDeportivoId, DateTime fechaAltaReserva, Estado estadoAsistencia)
{
    public int Id { get; set; } = id;
    public int PersonaId { get; set; } = personaId;
    public int EventoDeportivoId { get; set; } = eventoDeportivoId;
    public DateTime FechaAltaReserva { get; set; } = fechaAltaReserva;
    public Estado EstadoAsistencia { get; set; } = estadoAsistencia;

    public override string ToString()
    {
        return $"Reserva [Id={Id}, PersonaId={PersonaId}, EventoId={EventoDeportivoId}, FechaAlta={FechaAltaReserva:yyyy-MM-dd HH:mm}, Estado={EstadoAsistencia}]";
    }
}
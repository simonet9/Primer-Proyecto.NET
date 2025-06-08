using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validators
{
    public class ValidadorReserva(
        IRepositorioPersona repoPersona,
        IRepositorioEventoDeportivo repoEvento,
        IRepositorioReserva repoReserva)
    {
    public void Validar(Reserva reserva)
    {
        if (repoPersona.BuscarPorId(reserva.PersonaId) == null)
            throw new EntidadNotFoundException("La persona no existe.");

        var evento = repoEvento.BuscarPorId(reserva.EventoDeportivoId) ?? throw new EntidadNotFoundException("El evento no existe.");
        var cantidadReservas = repoReserva.ContarPorEvento(reserva.EventoDeportivoId);
        if (cantidadReservas >= evento.CupoMaximo)
            throw new CupoExcedidoException("No hay cupo disponible para este evento.");
    }
    }
}

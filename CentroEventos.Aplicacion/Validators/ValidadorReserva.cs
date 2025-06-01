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
        private readonly IRepositorioPersona _repoPersona = repoPersona;
        private readonly IRepositorioEventoDeportivo _repoEvento = repoEvento;
        private readonly IRepositorioReserva _repoReserva = repoReserva;

        public void Validar(Reserva reserva)
        {
            if (_repoPersona.BuscarPorId(reserva.PersonaId) == null)
                throw new EntidadNotFoundException("La persona no existe.");

            EventoDeportivo evento = _repoEvento.BuscarPorId(reserva.EventoDeportivoId) ?? throw new EntidadNotFoundException("El evento no existe.");
            int cantidadReservas = _repoReserva.ContarPorEvento(reserva.EventoDeportivoId);
            if (cantidadReservas >= evento.CupoMaximo)
                throw new CupoExcedidoException("No hay cupo disponible para este evento.");

            if (_repoReserva.ExisteReserva(reserva.PersonaId, reserva.EventoDeportivoId))
                throw new DuplicadoException("Ya existe una reserva para esta persona y evento.");
        }
    }
}

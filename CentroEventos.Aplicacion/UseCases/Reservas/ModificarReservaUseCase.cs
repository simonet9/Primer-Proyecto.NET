using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.CasosDeUso.Reservas
{
    public class ModificarReservaUseCase(
        IRepositorioReserva repoReserva,
        IServicioAutorizacion aut,
        ValidadorReserva validacion,
        IRepositorioEventoDeportivo repoEventos,
        IRepositorioPersona repoPersonas)
    {
        private readonly IRepositorioReserva _repoReserva = repoReserva;
        private readonly IServicioAutorizacion _aut = aut;
        private readonly ValidadorReserva _validacion = validacion;
        private readonly IRepositorioEventoDeportivo _repoEvento = repoEventos;
        private readonly IRepositorioPersona _repoPersona = repoPersonas;

        public void Ejecutar(Reserva reserva, int idUsuario)
        {
            // Verifica permisos
            if (!_aut.PoseeElPermiso(idUsuario, Permiso.ReservaModificacion))
                throw new FalloAutorizacionException("No tiene permiso para modificar reservas.");

            if (_repoPersona.BuscarPorId(reserva.PersonaId) == null)
                throw new EntidadNotFoundException("La persona no existe.");

            EventoDeportivo evento = _repoEvento.BuscarPorId(reserva.EventoDeportivoId) ?? throw new EntidadNotFoundException("El evento no existe.");
            int cantidadReservas = _repoReserva.ContarPorEvento(reserva.EventoDeportivoId);
            if (cantidadReservas >= evento.CupoMaximo)
                throw new CupoExcedidoException("No hay cupo disponible para este evento.");



            // Realiza la modificación
            _repoReserva.Modificar(reserva);
        }
    }
}

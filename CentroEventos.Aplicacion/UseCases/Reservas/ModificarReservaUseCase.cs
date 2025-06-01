using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.UseCases.Reservas
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

    public void Ejecutar(Reserva reserva, Guid idUsuario)
    {
        ValidarAutorizacion(idUsuario);
        ValidarExistenciaPersona(reserva.PersonaId);
        var evento = ObtenerEvento(reserva.EventoDeportivoId);
        ValidarCupoDisponible(reserva.EventoDeportivoId, evento.CupoMaximo);
        _validacion.Validar(reserva);
        _repoReserva.Modificar(reserva);
    }

    private void ValidarAutorizacion(Guid idUsuario)
    {
        if (!_aut.PoseeElPermiso(idUsuario, Permiso.ReservaModificacion))
            throw new FalloAutorizacionException("No tiene permiso para modificar reservas.");
    }

    private void ValidarExistenciaPersona(Guid personaId)
    {
        if (_repoPersona.BuscarPorId(personaId) is null)
            throw new EntidadNotFoundException("La persona no existe.");
    }

    private EventoDeportivo ObtenerEvento(Guid eventoId)
    {
        return _repoEvento.BuscarPorId(eventoId)
            ?? throw new EntidadNotFoundException("El evento no existe.");
    }

    private void ValidarCupoDisponible(Guid eventoId, int cupoMaximo)
    {
        if (_repoReserva.ContarPorEvento(eventoId) >= cupoMaximo)
            throw new CupoExcedidoException("No hay cupo disponible para este evento.");
    }
    }
}
using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Evento
{
    public class EliminarEventoDeportivoUseCase(IRepositorioEventoDeportivo repositorioEvento, IServicioAutorizacion aut, IRepositorioReserva repoReserva)
    {
        private readonly IRepositorioEventoDeportivo _repositorioEvento = repositorioEvento;
        private readonly IServicioAutorizacion _servicioAutorizacion = aut;
        private readonly IRepositorioReserva _repositorioReserva = repoReserva;

        public void Ejecutar(Guid eventoId, Guid usuarioId)
        {
            ValidarAutorizacion(usuarioId);
            ValidarReservasExistentes(eventoId);
            _repositorioEvento.Eliminar(eventoId);
        }
        private void ValidarAutorizacion(Guid usuarioId)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.EventoBaja))
            {
                throw new FalloAutorizacionException();
            }
        }
        private void ValidarReservasExistentes(Guid eventoId)
        {
            if (_repositorioReserva.ContarPorEvento(eventoId) > 0)
            {
                throw new OperacionInvalidaException("Existen reservas asociadas a este evento deportivo. No se puede eliminar.");
            }
        }
    }
}

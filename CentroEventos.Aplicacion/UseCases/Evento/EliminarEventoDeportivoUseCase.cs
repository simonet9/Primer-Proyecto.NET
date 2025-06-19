using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Evento
{
    public class EliminarEventoDeportivoUseCase(IRepositorioEventoDeportivo repositorioEvento, IServicioAutorizacion aut, IRepositorioReserva repoReserva)
    : UseCaseConAutorizacion(aut)
    {
        public void Ejecutar(Guid eventoId, Guid usuarioId)
        {
            ValidarAutorizacion(usuarioId, Permiso.EventoBaja);
            ValidarReservasExistentes(eventoId);
            var evento = repositorioEvento.BuscarPorId(eventoId) ?? throw new EntidadNotFoundException("Evento deportivo no encontrado.");
            repositorioEvento.Eliminar(evento);
            repositorioEvento.GuardarCambios();
        }
        private void ValidarReservasExistentes(Guid eventoId)
        {
            if (repoReserva.ContarPorEvento(eventoId) > 0)
            {
                throw new OperacionInvalidaException("Existen reservas asociadas a este evento deportivo. No se puede eliminar.");
            }
        }
    }
}

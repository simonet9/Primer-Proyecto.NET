using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Reservas
{
    public class EliminarReservaUseCase(
        IRepositorioReserva repoReserva,
        IServicioAutorizacion servicioAutorizacion
        )
    {
        private readonly IRepositorioReserva _repoReserva = repoReserva;
        private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;

        public void Ejecutar(Reserva datosReserva, Guid idUsuario)
        {
            ValidarAutorizacion(idUsuario);
            _repoReserva.Eliminar(datosReserva.Id);
        }
        private void ValidarAutorizacion(Guid idUsuario)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaAlta))
                throw new FalloAutorizacionException();
        }
    }
}

using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso.Reservas
{
    public class EliminarReservaUseCase(
        IRepositorioReserva repoReserva,
        IServicioAutorizacion servicioAutorizacion
        )
    {
        private readonly IRepositorioReserva _repoReserva = repoReserva;
        private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;

        public void Ejecutar(Reserva datosReserva, int idUsuario)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaBaja))
                throw new FalloAutorizacionException();
            _repoReserva.Eliminar(datosReserva.Id);
        }
    }
}

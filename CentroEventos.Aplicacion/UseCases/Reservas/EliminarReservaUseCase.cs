using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Reservas
{
    public class EliminarReservaUseCase(
        IRepositorioReserva repoReserva,
        IServicioAutorizacion servicioAutorizacion
    ) : UseCaseConAutorizacion(servicioAutorizacion)
    {
        public void Ejecutar(Guid idReserva, Guid idUsuario)
        {
            ValidarAutorizacion(idUsuario, Permiso.ReservaBaja);
            var reserva = repoReserva.BuscarPorId(idReserva) ?? throw new EntidadNotFoundException("Reserva no encontrada.");
            repoReserva.Eliminar(reserva);
            repoReserva.GuardarCambios();
        }
    }
}
using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.UseCases.Reservas
{
    public class EliminarReservaUseCase(
        IRepositorioReserva repoReserva,
        IServicioAutorizacion servicioAutorizacion, ValidadorReserva validador
        ) : UseCaseConAutorizacion(servicioAutorizacion)
    {
        public void Ejecutar(Reserva datosReserva, Guid idUsuario)
        {
            ValidarAutorizacion(idUsuario, Permiso.ReservaBaja);
            validador.Validar(datosReserva);
            var reserva = repoReserva.BuscarPorId(datosReserva.Id) ?? throw new EntidadNotFoundException("Reserva no encontrada.");
            repoReserva.Eliminar(reserva);
            repoReserva.GuardarCambios();
        }
    }
}

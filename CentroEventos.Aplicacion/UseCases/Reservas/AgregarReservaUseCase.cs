using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.UseCases.Reservas
{
    public class ReservaAltaUseCase(
        IRepositorioReserva repoReserva,
        IServicioAutorizacion servicioAutorizacion,
        ValidadorReserva validador
        ) : UseCaseConAutorizacion(servicioAutorizacion)
    {
        public void Ejecutar(Reserva datosReserva, Guid idUsuario)
        {
            ValidarAutorizacion(idUsuario,Permiso.EventoAlta);
            validador.Validar(datosReserva);
            if (repoReserva.BuscarPorId(datosReserva.Id) != null)
                throw new OperacionInvalidaException("Ya existe una reserva con el mismo ID.");
            repoReserva.Agregar(datosReserva);
        }
    }
}

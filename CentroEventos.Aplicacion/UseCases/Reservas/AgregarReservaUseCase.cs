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
        )
    {
        private readonly IRepositorioReserva _repoReserva = repoReserva;
        private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;
        private readonly ValidadorReserva _validador = validador;

        public void Ejecutar(Reserva datosReserva, Guid idUsuario)
        {
            ValidarAutorizacion(idUsuario);
            _validador.Validar(datosReserva);
            _repoReserva.Agregar(datosReserva);
        }

        private void ValidarAutorizacion(Guid idUsuario)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaAlta))
                throw new FalloAutorizacionException();
        }
    }
}

using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.CasosDeUso.Reservas
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

        public void Ejecutar(Reserva datosReserva, int idUsuario)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaAlta))
                throw new FalloAutorizacionException();

            _validador.Validar(datosReserva);
            _repoReserva.Agregar(datosReserva);
        }
    }
}

using CentroEventos.Aplicacion.Entities;
    using CentroEventos.Aplicacion.Enum;
    using CentroEventos.Aplicacion.Exceptions;
    using CentroEventos.Aplicacion.Interfaces;
    using CentroEventos.Aplicacion.Validators;
    
    namespace CentroEventos.Aplicacion.UseCases.Reservas
    {
        public class ModificarReservaUseCase(
            IRepositorioReserva repoReserva,
            IServicioAutorizacion aut) : UseCaseConAutorizacion(aut)
        {
            public void Ejecutar(Reserva reserva, Guid idUsuario)
            {
                ValidarAutorizacion(idUsuario, Permiso.ReservaModificacion);
                repoReserva.Modificar(reserva);
                repoReserva.GuardarCambios();
            }
        }
    }
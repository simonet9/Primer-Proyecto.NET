using CentroEventos.Aplicacion.Entities;
    using CentroEventos.Aplicacion.Enum;
    using CentroEventos.Aplicacion.Exceptions;
    using CentroEventos.Aplicacion.Interfaces;
    using CentroEventos.Aplicacion.Validators;
    
    namespace CentroEventos.Aplicacion.UseCases.Reservas
    {
        public class ModificarReservaUseCase(
            IRepositorioReserva repoReserva,
            IServicioAutorizacion aut,
            ValidadorReserva validacion,
            IRepositorioEventoDeportivo repoEventos,
            IRepositorioPersona repoPersonas)
        {
            private readonly IRepositorioReserva _repoReserva = repoReserva;
            private readonly IServicioAutorizacion _aut = aut;
            private readonly ValidadorReserva _validacion = validacion;
            private readonly IRepositorioEventoDeportivo _repoEvento = repoEventos;
            private readonly IRepositorioPersona _repoPersona = repoPersonas;
    
            public void Ejecutar(Reserva reserva, Guid idUsuario)
            {
                ValidarAutorizacion(idUsuario);
    
                var reservaExistente = _repoReserva.BuscarPorId(reserva.Id)
                    ?? throw new EntidadNotFoundException("La reserva no existe.");
    
                _validacion.Validar(reserva);
    
                _repoReserva.Modificar(reserva);
            }
    
            private void ValidarAutorizacion(Guid idUsuario)
            {
                if (!_aut.PoseeElPermiso(idUsuario, Permiso.ReservaModificacion))
                    throw new FalloAutorizacionException("No tiene permiso para modificar reservas.");
            }
        }
    }
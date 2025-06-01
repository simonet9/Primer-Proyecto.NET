using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.UseCases.Personas
{
    public class ModificarPersonaUseCase(
        IRepositorioPersona repositorioPersona, 
        ValidadorPersona validadorPersona, 
        IServicioAutorizacion servicioAutorizacion)
    {
        private readonly IRepositorioPersona _repositorioPersona = repositorioPersona;
        private readonly ValidadorPersona _validadorPersona = validadorPersona;
        private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;

        public void ActualizarPersona(Persona persona, Guid idUsuario, string? mensajeError = null)
        {
            ValidarAutorizacion(idUsuario, mensajeError);
            _validadorPersona.Validar(persona);
            _repositorioPersona.Modificar(persona);
        }

        private void ValidarAutorizacion(Guid idUsuario, string? mensajeError)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioModificacion))
            {
                throw new FalloAutorizacionException(mensajeError);
            }
        }
    }
}
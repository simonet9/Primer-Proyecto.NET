using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Users
{
    public class EliminarUsuarioUseCase(IRepositorioUsuario repoUsuario, IServicioAutorizacion aut)
        : UseCaseConAutorizacion(aut)
    {
        public void Ejecutar(Guid idUsuarioAEliminar, Guid idUsuarioEjecutor)
        {
            ValidarAutorizacion(idUsuarioEjecutor, Permiso.UsuarioBaja);
            var usuario = repoUsuario.ObtenerPorId(idUsuarioAEliminar) ?? throw new EntidadNotFoundException("Usuario no encontrado.");
            repoUsuario.Eliminar(usuario);
            repoUsuario.GuardarCambios();
        }
    }
}
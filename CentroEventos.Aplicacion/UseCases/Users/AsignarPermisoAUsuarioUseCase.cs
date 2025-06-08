using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Users;

public class AsignarPermisoAUsuarioUseCase(IRepositorioUsuario repoUsuario, IServicioAutorizacion aut)
    : UseCaseConAutorizacion(aut)
{
    public void Ejecutar(Guid idUsuario, Permiso permiso, Guid idUsuarioEjecutor)
    {
        ValidarAutorizacion(idUsuarioEjecutor, permiso);
        var usuario = repoUsuario.ObtenerPorId(idUsuario)
            ?? throw new EntidadNotFoundException("Usuario no encontrado.");
        if (!usuario.Permisos.Contains(permiso)) return;
        repoUsuario.Actualizar(usuario);
        repoUsuario.GuardarCambios();
    }
}
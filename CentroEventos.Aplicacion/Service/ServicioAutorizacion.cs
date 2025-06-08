using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Service
{
    public class ServicioAutorizacion(IRepositorioUsuario repo) : IServicioAutorizacion
    {
        public bool PoseeElPermiso(Guid idUsuario, Permiso permiso)
        {
            var usuario = repo.ObtenerPorId(idUsuario);
            return usuario != null && usuario.Permisos.Any(p => p == permiso);
        }
        
    }

}
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Service
{
    public class ServicioAutorizacionProvisorio : IServicioAutorizacion
    {
        public bool PoseeElPermiso(int idUsuario, Permiso permiso)
        {
            return idUsuario == 1;
        }
    }
}
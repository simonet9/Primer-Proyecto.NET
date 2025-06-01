using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Service
{
    public class ServicioAutorizacionProvisorio : IServicioAutorizacion
    {
        private static readonly Guid AdminId = new Guid("00000000-0000-0000-0000-000000000001");
        public bool PoseeElPermiso(Guid idUsuario, Permiso permiso)
        {
            return idUsuario == AdminId;
        }
    }
}
using CentroEventos.Aplicacion.Enum;

namespace CentroEventos.Aplicacion.Interfaces
{
    public interface IServicioAutorizacion
    {
        bool PoseeElPermiso(int IdUsuario, Permiso permiso);
    }
}
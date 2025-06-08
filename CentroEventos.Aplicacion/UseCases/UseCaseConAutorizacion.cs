using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases;

public abstract class UseCaseConAutorizacion(IServicioAutorizacion servicioAutorizacion)
{
    protected void ValidarAutorizacion(Guid idUsuario, Permiso permiso)
    {
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, permiso))
            throw new FalloAutorizacionException();
    }
}
using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Service;

public class ServicioAutenticacion : IServicioAutenticacion
{
    private Usuario? _usuarioActual;

    public Usuario? ObtenerUsuarioActual() => _usuarioActual;

    public void IniciarSesion(Usuario usuario)
    {
        _usuarioActual = usuario;
    }

    public void CerrarSesion()
    {
        _usuarioActual = null;
    }
}
using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Service;

public class UsuarioLogueado
{
    public Usuario? UsuarioActual { get; private set; }

    public void SetUsuario(Usuario usuario)
    {
        UsuarioActual = usuario;
    }

    public void Limpiar()
    {
        UsuarioActual = null;
    }
    public bool ExisteUsuarioLogueado() => UsuarioActual != null;
}
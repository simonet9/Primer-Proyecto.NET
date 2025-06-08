using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioAutenticacion
{
    Usuario? ObtenerUsuarioActual();
    void IniciarSesion(Usuario usuario);
    void CerrarSesion();
}
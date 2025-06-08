using CentroEventos.Aplicacion.Entities;
namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioUsuario
{
    Usuario? ObtenerPorEmail(string email);
    Usuario? ObtenerPorId(Guid id);
    void Agregar(Usuario usuario);
    void Actualizar(Usuario usuario);
    List<Usuario> ObtenerTodos();
    bool ExisteAlguno();
    void GuardarCambios();
    void Eliminar(Usuario usuario);

}
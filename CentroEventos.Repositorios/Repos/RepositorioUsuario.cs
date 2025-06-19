using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.Data;

namespace CentroEventos.Repositorios.Repos;

public class RepositorioUsuario(MyContext context) : IRepositorioUsuario
{
    public Usuario? ObtenerPorEmail(string email) => context.Usuarios.FirstOrDefault(u => u.Email == email);
    public Usuario? ObtenerPorId(Guid id) => context.Usuarios.FirstOrDefault(u => u.Id == id);
    public void Agregar(Usuario usuario) => context.Usuarios.Add(usuario);
    public void Actualizar(Usuario usuario) => context.Usuarios.Update(usuario);
    public List<Usuario> ObtenerTodos() => context.Usuarios.ToList();
    public bool ExisteAlguno() => context.Usuarios.Any();
    public void GuardarCambios() => context.SaveChanges();
    public void Eliminar(Usuario usuario) =>  context.Usuarios.Remove(usuario);

}
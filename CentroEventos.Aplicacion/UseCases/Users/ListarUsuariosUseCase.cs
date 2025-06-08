using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.UseCases.Users
{
    public class ListarUsuariosUseCase(IRepositorioUsuario repo)
    {
        public List<Usuario> Ejecutar()
        {
            var usuarios = repo.ObtenerTodos();
            return ValidadorListas.ValidarNoVacia(usuarios, "No hay usuarios registrados.");
        }
    }
}
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;
using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.UseCases.Users;

public class RegistrarUsuarioUseCase(
    IRepositorioUsuario repoUsuario,
    IServicioAutorizacion auth)
    : UseCaseConAutorizacion(auth)
{
    public void Ejecutar(string nombre, string apellido, string email, string password)
    {
        // Validar los datos del usuario
        ValidadorUsuario.Validar(nombre, apellido, password, email);
        // Crear nuevo usuario
        var nuevoUsuario = new Usuario(nombre, apellido, email, password);

        // Sí es el primer usuario del sistema, asignarle todos los permisos
        if (!repoUsuario.ExisteAlguno())
        {   
            foreach (var p in System.Enum.GetValues<Permiso>())
                nuevoUsuario.Permisos.Add(p);
        }
        ValidarAutorizacion(nuevoUsuario.Id, Permiso.UsuarioAlta);
        // Agregar el usuario al repositorio y guardar cambios
        repoUsuario.Agregar(nuevoUsuario);
        repoUsuario.GuardarCambios();
    }
}
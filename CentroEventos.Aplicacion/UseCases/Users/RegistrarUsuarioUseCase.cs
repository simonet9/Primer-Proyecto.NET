using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;
using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;

namespace CentroEventos.Aplicacion.UseCases.Users;

public class RegistrarUsuarioUseCase(IRepositorioUsuario repoUsuario)
{
    public void Ejecutar(string nombre, string apellido, string email, string password)
    {
        try
        {
            ValidadorUsuario.Validar(nombre, apellido, password, email);

            if (repoUsuario.ObtenerPorEmail(email) != null)
            {
                throw new DuplicadoException("Ya existe un usuario con ese email");
            }

            var nuevoUsuario = new Usuario(nombre, apellido, email, password);

            if (!repoUsuario.ExisteAlguno())
            {
                foreach (var p in System.Enum.GetValues<Permiso>())
                {
                    nuevoUsuario.Permisos.Add(p);
                }
            }

            // Agregar el usuario y guardar cambios
            repoUsuario.Agregar(nuevoUsuario);
            repoUsuario.GuardarCambios();
        }
        catch (DuplicadoException)
        {
            throw;
        }
        catch (ValidacionExcepcion)
        {
            throw;
        }
        catch (Exception)
        {
            throw new OperacionInvalidaException("Error al registrar el usuario");
        }
    }
}
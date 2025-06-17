using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;
using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Helpers;

namespace CentroEventos.Aplicacion.UseCases.Users;

public class RegistrarUsuarioUseCase(IRepositorioUsuario repoUsuario)
{
    public void Ejecutar(string nombre, string apellido, string email, string password, List<Permiso> datosPermisos)
    {
        try
        {
            ValidadorUsuario.Validar(nombre, apellido, password, email);

            if (repoUsuario.ObtenerPorEmail(email) != null)
            {
                throw new DuplicadoException("Ya existe un usuario con ese email");
            }
            var hashPassword = HashHelper.CalcularHash(password);
            var usuario = new Usuario(nombre, apellido, email, hashPassword,datosPermisos);


            if (!repoUsuario.ExisteAlguno())
            {
                foreach (var p in System.Enum.GetValues<Permiso>())
                {
                    usuario.Permisos.Add(p);
                }
            }

            repoUsuario.Agregar(usuario);
            repoUsuario.GuardarCambios();
        }
        catch (Exception ex)
        {
            throw new OperacionInvalidaException(ex.Message);
        }
    }
}
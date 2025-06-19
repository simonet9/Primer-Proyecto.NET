using CentroEventos.Aplicacion.Exceptions;

namespace CentroEventos.Aplicacion.Validators;

public static class ValidadorUsuario
{
    public static void Validar(string nombre, string apellido, string password, string email)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ValidacionExcepcion("El nombre es obligatorio.");
        if (string.IsNullOrWhiteSpace(apellido))
            throw new ValidacionExcepcion("El apellido es obligatorio.");
        if (string.IsNullOrWhiteSpace(password))
            throw new ValidacionExcepcion("La contraseña es obligatoria");
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            throw new ValidacionExcepcion("El mail debe ser un email válido.");
    }
}

using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;
namespace CentroEventos.Aplicacion.Validators
{
    public static class ValidadorPersona
    {
        public static void Validar(Persona persona)
        {
            if (string.IsNullOrWhiteSpace(persona.Nombre))
                throw new ValidacionExcepcion("El nombre no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(persona.Apellido))
                throw new ValidacionExcepcion("El apellido no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(persona.Dni))
                throw new ValidacionExcepcion("El DNI no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(persona.Email))
                throw new ValidacionExcepcion("El email no puede estar vacío.");
            
            if (!persona.Email.Contains('@'))
                throw new ValidacionExcepcion("El email debe contener un '@'.");
        }
    }

}

using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
namespace CentroEventos.Aplicacion.Validators
{
    public class ValidadorPersona(IRepositorioPersona repoPersona)
    {
        private readonly IRepositorioPersona _repoPersona = repoPersona;

        public void Validar(Persona persona)
        {
            if (string.IsNullOrWhiteSpace(persona.Nombre))
                throw new ValidacionExcepcion("El nombre no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(persona.Apellido))
                throw new ValidacionExcepcion("El apellido no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(persona.DNI))
                throw new ValidacionExcepcion("El DNI no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(persona.Email))
                throw new ValidacionExcepcion("El email no puede estar vacío.");

            if (_repoPersona.ExisteDNI(persona.DNI, persona.Id))
                throw new DuplicadoException("El DNI ya está registrado.");

            if (_repoPersona.ExisteEmail(persona.Email, persona.Id))
                throw new DuplicadoException("El email ya está registrado.");
        }
    }

}

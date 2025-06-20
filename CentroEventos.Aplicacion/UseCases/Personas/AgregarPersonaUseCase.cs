using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.UseCases.Personas
{
    public class AgregarPersonaUseCase(IRepositorioPersona repo)
    {
        public void Ejecutar(Persona persona)
        {
            ValidadorPersona.Validar(persona);
            if (repo.ExisteDni(persona.Dni))
                throw new DuplicadoException("Ya existe una persona con el mismo DNI.");
            if (repo.ObtenerPorEmail(persona.Email))
                throw new DuplicadoException("Ya existe una persona con el mismo email.");
            repo.Agregar(persona);
            repo.GuardarCambios();
        }
    }
}

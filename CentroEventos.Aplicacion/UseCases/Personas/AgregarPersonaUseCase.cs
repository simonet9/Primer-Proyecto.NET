using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
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
            if (repo.BuscarPorId(persona.Id) != null)
                throw new OperacionInvalidaException("Ya existe una persona con el mismo ID.");
            repo.Agregar(persona);
            repo.GuardarCambios();
        }
    }
}

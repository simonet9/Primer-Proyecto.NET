using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.UseCases.Personas
{
    public class ModificarPersonaUseCase(
        IRepositorioPersona repositorioPersona)
    {
        public void Ejecutar(Persona persona)
        {
            ValidadorPersona.Validar(persona);
            repositorioPersona.Modificar(persona);
            repositorioPersona.GuardarCambios();
        }
    }
}
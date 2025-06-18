using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Personas
{
    public class EliminarPersonaUseCase(IRepositorioPersona repo, IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva)
    {
        public void Ejecutar(Guid idPersona)
        {
            ValidarAsociaciones(idPersona);
            var persona  = repo.BuscarPorId(idPersona) ?? throw new EntidadNotFoundException("Persona no encontrada.");
            repo.Eliminar(persona);
            repo.GuardarCambios();
        }
        private void ValidarAsociaciones(Guid idPersona)
        {
            if (repoEvento.ExisteEventoConResponsable(idPersona))
                throw new OperacionInvalidaException("No se puede eliminar la persona porque es responsable de uno o más eventos deportivos.");

            if (repoReserva.ListarPorPersona(idPersona).Count > 0)
                throw new OperacionInvalidaException("No se puede eliminar la persona porque tiene reservas asociadas.");
        } 
    }
}

using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Personas
{
    public class EliminarPersonaUseCase(IRepositorioPersona repo, IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva, IServicioAutorizacion aut)
    {
        public void Ejecutar(Guid idPersona, Guid idUsuario)
        {
            ValidarAsociaciones(idPersona);
            var persona  = repo.BuscarPorId(idPersona) ?? throw new EntidadNotFoundException("Persona no encontrada.");
            repo.Eliminar(persona);
            repo.GuardarCambios();
        }
        private void ValidarAsociaciones(Guid idPersona)
        {
            if (repoEvento.ExisteEventoConResponsable(idPersona) || repoReserva.ListarPorPersona(idPersona).Count > 0)
                throw new OperacionInvalidaException("La persona tiene eventos o reservas asociadas.");
        } 
    }
}

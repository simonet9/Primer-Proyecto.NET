using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases
{
    public class ListarAsistenciaAEventoUseCase(
        IRepositorioEventoDeportivo repoEvento,
        IRepositorioReserva repoReserva,
        IRepositorioPersona repoPersona)
    {
        private readonly IRepositorioEventoDeportivo _repoEvento = repoEvento;
        private readonly IRepositorioReserva _repoReserva = repoReserva;
        private readonly IRepositorioPersona _repoPersona = repoPersona;

        public List<Persona> Ejecutar(Guid eventoId)
        {
            var evento = _repoEvento.BuscarPorId(eventoId) 
                ?? throw new EntidadNotFoundException("El evento no existe.");

            if (evento.FechaHoraInicio > DateTime.Now)
                throw new InvalidOperationException("El evento aún no ha ocurrido.");

            var reservas = _repoReserva.ListarPorEvento(eventoId);

            return reservas
                .Select(r => _repoPersona.BuscarPorId(r.PersonaId))
                .Where(p => p != null)
                .ToList()!;
        }
    }
}
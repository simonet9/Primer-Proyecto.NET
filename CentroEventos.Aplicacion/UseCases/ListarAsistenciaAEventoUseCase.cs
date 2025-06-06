using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

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
            var evento = ValidarYObtenerEvento(eventoId);
            ValidarFechaEvento(evento);
            
            var reservas = _repoReserva.ListarPorEvento(eventoId);
            var asistentes = ObtenerAsistentesDeReservas(reservas);
            
            return ValidadorListas.ValidarNoVacia(asistentes,"No hay personas registradas para este evento.");
        }

        private EventoDeportivo ValidarYObtenerEvento(Guid eventoId)
        {
            return _repoEvento.BuscarPorId(eventoId) 
                   ?? throw new EntidadNotFoundException("Evento deportivo no encontrado.");
        }

        private void ValidarFechaEvento(EventoDeportivo evento)
        {
            if (evento.FechaHoraInicio > DateTime.Now)
            {
                throw new InvalidOperationException("El evento aún no ha comenzado.");
            }
        }

        private List<Persona> ObtenerAsistentesDeReservas(IEnumerable<Reserva> reservas)
        {
            return reservas
                .Select(r => _repoPersona.BuscarPorId(r.PersonaId))
                .Where(p => p != null)
                .ToList()!;
        }
    }
}
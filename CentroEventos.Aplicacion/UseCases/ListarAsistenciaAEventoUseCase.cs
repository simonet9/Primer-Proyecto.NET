using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso
{
    public class ListarAsistenciaAEventoUseCase(
        IRepositorioEventoDeportivo repoEvento,
        IRepositorioReserva repoReserva,
        IRepositorioPersona repoPersona)
    {
        private readonly IRepositorioEventoDeportivo _repoEvento = repoEvento;
        private readonly IRepositorioReserva _repoReserva = repoReserva;
        private readonly IRepositorioPersona _repoPersona = repoPersona;

        public List<Persona> Ejecutar(int eventoId)
        {
            EventoDeportivo? evento = _repoEvento.BuscarPorId(eventoId) ?? throw new EntidadNotFoundException("El evento no existe.");


            if (evento.FechaHoraInicio > DateTime.Now)
                throw new InvalidOperationException("El evento aún no ha ocurrido.");

            List<Reserva> reservas = _repoReserva.ListarPorEvento(eventoId);

            List<Persona> asistentes = new List<Persona>();
            foreach (Reserva reserva in reservas)
            {
                Persona? persona = _repoPersona.BuscarPorId(reserva.PersonaId);
                if (persona == null)
                    continue;
                asistentes.Add(persona);
            }
            return asistentes;
        }
    }
}

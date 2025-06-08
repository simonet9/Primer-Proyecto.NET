using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.UseCases.Evento
{
    public class ListarEventosConCupoDisponibleUseCase(
        IRepositorioEventoDeportivo repoEvento,
        IRepositorioReserva repoReserva)
    {
        public List<EventoDeportivo> Ejecutar()
        {
            var todosLosEventos = repoEvento.Listar();
            var eventosDisponibles = FiltrarEventosDisponibles(todosLosEventos);
            
            return ValidadorListas.ValidarNoVacia(
                eventosDisponibles, 
                "No hay eventos disponibles con cupo.");
        }

        private List<EventoDeportivo> FiltrarEventosDisponibles(List<EventoDeportivo> eventos)
        {
            return eventos
                .Where(TieneFechaValida)
                .Where(TieneCupoDisponible)
                .ToList();
        }

        private static bool TieneFechaValida(EventoDeportivo evento)
        {
            return evento.FechaHoraInicio > DateTime.Now;
        }

        private bool TieneCupoDisponible(EventoDeportivo evento)
        {
            var reservasActuales = repoReserva.ContarPorEvento(evento.Id);
            return reservasActuales < evento.CupoMaximo;
        }

    }
}
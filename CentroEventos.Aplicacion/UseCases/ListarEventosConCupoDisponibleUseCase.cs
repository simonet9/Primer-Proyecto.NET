using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases
{
    public class ListarEventosConCupoDisponibleUseCase(
        IRepositorioEventoDeportivo repoEvento,
        IRepositorioReserva repoReserva)
    {
        private readonly IRepositorioEventoDeportivo _repoEvento = repoEvento;
        private readonly IRepositorioReserva _repoReserva = repoReserva;

        public List<EventoDeportivo> Ejecutar()
        {
            DateTime ahora = DateTime.Now;

            return _repoEvento.Listar()
                .Where(evento => evento.FechaHoraInicio > ahora &&
                                 _repoReserva.ContarPorEvento(evento.Id) < evento.CupoMaximo)
                .ToList();
        }
    }
}
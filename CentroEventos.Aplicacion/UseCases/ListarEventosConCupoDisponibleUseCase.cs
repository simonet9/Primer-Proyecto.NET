using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso
{
    public class ListarEventosConCupoDisponibleUseCase(
        IRepositorioEventoDeportivo repoEvento,
        IRepositorioReserva repoReserva)
    {
        private readonly IRepositorioEventoDeportivo _repoEvento = repoEvento;
        private readonly IRepositorioReserva _repoReserva = repoReserva;

        public List<EventoDeportivo> Ejecutar()
        {
            List<EventoDeportivo> resultado = new List<EventoDeportivo>();
            List<EventoDeportivo> todos = _repoEvento.Listar();
            DateTime ahora = DateTime.Now;

            foreach (EventoDeportivo evento in todos)
            {
                if (evento.FechaHoraInicio > ahora)
                {
                    int reservasActuales = _repoReserva.ContarPorEvento(evento.Id);
                    if (reservasActuales < evento.CupoMaximo)
                    {
                        resultado.Add(evento);
                    }
                }
            }
            return resultado;
        }
    }
}

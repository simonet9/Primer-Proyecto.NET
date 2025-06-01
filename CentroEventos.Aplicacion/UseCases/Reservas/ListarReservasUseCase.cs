using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Reservas
{
    public class ListarReservasUseCase(
        IRepositorioReserva repoReserva
        )
    {
        private readonly IRepositorioReserva _repoReserva = repoReserva;

        public List<Reserva> Ejecutar()
        {
            return _repoReserva.Listar();
        }
    }
}

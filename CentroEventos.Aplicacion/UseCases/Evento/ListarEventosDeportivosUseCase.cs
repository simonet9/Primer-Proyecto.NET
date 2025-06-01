using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso.Evento
{
    public class ListarEventosDeportivoUseCase(IRepositorioEventoDeportivo repo)
    {
        private readonly IRepositorioEventoDeportivo _repo = repo;

        public List<EventoDeportivo> Ejecutar()
        {
            return _repo.Listar();
        }
    }
}

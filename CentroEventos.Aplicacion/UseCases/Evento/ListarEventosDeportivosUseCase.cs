using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.UseCases.Evento
{
    public class ListarEventosDeportivoUseCase(IRepositorioEventoDeportivo repo)
    {
        private readonly IRepositorioEventoDeportivo _repo = repo;

        public List<EventoDeportivo> Ejecutar()
        {
            var eventos = _repo.Listar();
            return ValidadorListas.ValidarNoVacia(eventos, "No hay eventos deportivos registrados.");
        }
    }
}

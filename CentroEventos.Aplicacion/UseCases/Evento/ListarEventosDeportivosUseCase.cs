using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.UseCases.Evento
{
    public class ListarEventosDeportivoUseCase(IRepositorioEventoDeportivo repo)
    {
        public List<EventoDeportivo> Ejecutar()
        {
            var eventos = repo.Listar();
            return ValidadorListas.ValidarNoVacia(eventos, "No hay eventos deportivos registrados.");
        }
    }
}

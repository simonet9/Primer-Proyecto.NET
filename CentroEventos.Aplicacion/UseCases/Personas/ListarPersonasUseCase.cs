using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.UseCases.Personas
{
    public class ListarPersonasUseCase(IRepositorioPersona repo)
    {
        private readonly IRepositorioPersona _repo = repo;
        public List<Persona> Ejecutar()
        {
            var personas = _repo.Listar();
            return ValidadorListas.ValidarNoVacia(personas, "No hay personas registradas.");
        }
    }
}

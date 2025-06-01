using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso.Personas
{
    public class ListarPersonasUseCase(IRepositorioPersona repo)
    {
        private readonly IRepositorioPersona _repo = repo;
        public List<Persona> Ejecutar()
        {
            return _repo.Listar();
        }
    }
}

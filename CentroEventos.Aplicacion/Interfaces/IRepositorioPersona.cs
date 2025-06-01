using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Interfaces
{
    public interface IRepositorioPersona
    {
        Persona? BuscarPorId(Guid id);
        bool ExisteDNI(string dni, Guid idIgnorado = default);
        bool ExisteEmail(string email, Guid idIgnorado = default);
        void Agregar(Persona persona);
        void Modificar(Persona persona);
        void Eliminar(Guid id);
        List<Persona> Listar();
    }
}

using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Interfaces
{
    public interface IRepositorioPersona
    {
        Persona? BuscarPorId(int id);
        bool ExisteDNI(string dni, int idIgnorado = 0);
        bool ExisteEmail(string email, int idIgnorado = 0);
        void Agregar(Persona persona);
        void Modificar(Persona persona);
        void Eliminar(int id);
        List<Persona> Listar();
    }
}

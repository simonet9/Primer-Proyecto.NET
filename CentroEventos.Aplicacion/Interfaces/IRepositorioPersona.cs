using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Interfaces
{
    public interface IRepositorioPersona
    {
        Persona? BuscarPorId(Guid id);
        bool ExisteDni(string dni, Guid idIgnorado = default);
        void Agregar(Persona persona);
        void Modificar(Persona persona);
        void Eliminar(Persona persona);
        void GuardarCambios();
        List<Persona> Listar();
        Persona? ObtenerPorDocumento(string documento);
        bool ObtenerPorEmail(string email);
    }
}

using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Interfaces
{
    public interface IRepositorioEventoDeportivo
    {
        EventoDeportivo? BuscarPorId(int id);
        void Agregar(EventoDeportivo evento);
        void Modificar(EventoDeportivo evento);
        void Eliminar(int id);
        List<EventoDeportivo> Listar();
        List<EventoDeportivo> ListarFuturosConCupoDisponible();
        List<EventoDeportivo> ListarPorResponsable(int personaId);
        bool ExisteEventoConResponsable(int responsableId);

    }
}

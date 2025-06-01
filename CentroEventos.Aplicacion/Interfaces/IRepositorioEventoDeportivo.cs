using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Interfaces
{
    public interface IRepositorioEventoDeportivo
    {
        EventoDeportivo? BuscarPorId(Guid id);
        void Agregar(EventoDeportivo evento);
        void Modificar(EventoDeportivo evento);
        void Eliminar(Guid id);
        List<EventoDeportivo> Listar();
        List<EventoDeportivo> ListarFuturosConCupoDisponible();
        List<EventoDeportivo> ListarPorResponsable(Guid personaId);
        bool ExisteEventoConResponsable(Guid responsableId);

    }
}

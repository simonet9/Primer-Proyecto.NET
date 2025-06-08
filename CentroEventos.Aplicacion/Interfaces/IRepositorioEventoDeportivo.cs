using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Interfaces
{
    public interface IRepositorioEventoDeportivo
    {
        EventoDeportivo? BuscarPorId(Guid id);
        void Agregar(EventoDeportivo evento);
        void Modificar(EventoDeportivo evento);
        void Eliminar(EventoDeportivo evento);
        List<EventoDeportivo> Listar();
        void GuardarCambios();
        bool ExisteEventoConResponsable(Guid responsableId);

    }
}

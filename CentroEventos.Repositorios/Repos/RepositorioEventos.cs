using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.Data;

namespace CentroEventos.Repositorios.Repos
{
    public class RepositorioEventoDeportivo(MyContext context) : IRepositorioEventoDeportivo
    {
        public void Agregar(EventoDeportivo evento) => context.EventosDeportivos.Add(evento);
        public EventoDeportivo? BuscarPorId(Guid id) => context.EventosDeportivos.Find(id);
        public void Eliminar(EventoDeportivo evento)=>context.EventosDeportivos.Remove(evento);
        public List<EventoDeportivo> Listar() => context.EventosDeportivos.ToList();
        public void GuardarCambios() => context.SaveChanges();
        public void Modificar(EventoDeportivo evento) => context.EventosDeportivos.Update(evento);
        public bool ExisteEventoConResponsable(Guid responsableId) => context.EventosDeportivos.Any(e => e.ResponsableId == responsableId);
    }
}
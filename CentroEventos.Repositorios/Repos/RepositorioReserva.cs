
using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.Data;

namespace CentroEventos.Repositorios.Repos
{
    public class RepositorioReserva(MyContext context) : IRepositorioReserva
    {
        public bool BuscarPersonaPorReserva(Guid personaId) => context.Reservas.Any(r => r.PersonaId == personaId);

        public void Agregar(Reserva reserva) => context.Reservas.Add(reserva);
        public Reserva? BuscarPorId(Guid id) => context.Reservas.Find(id);
        public void Eliminar(Reserva reserva) => context.Reservas.Remove(reserva);
        public List<Reserva> Listar() => context.Reservas.ToList();
        public void Modificar(Reserva reserva)=> context.Reservas.Update(reserva);
        public int ContarPorEvento(Guid eventoId) => context.Reservas.Count(r => r.EventoDeportivoId == eventoId);
        public bool ExisteReserva(Guid personaId, Guid eventoId) => context.Reservas.Any(r => r.PersonaId == personaId && r.EventoDeportivoId == eventoId);
        public void GuardarCambios() =>  context.SaveChanges();
        public List<Reserva> ListarPorEvento(Guid eventoId) => context.Reservas.Where(r => r.EventoDeportivoId == eventoId).ToList();
        public List<Reserva> ListarPorPersona(Guid personaId) => context.Reservas.Where(r => r.PersonaId == personaId).ToList();

    }
}
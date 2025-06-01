using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Interfaces
{
    public interface IRepositorioReserva
    {
        Reserva? BuscarPorId(Guid id);
        void Agregar(Reserva reserva);
        void Modificar(Reserva reserva);
        void Eliminar(Guid id);
        List<Reserva> Listar();
        int ContarPorEvento(Guid eventoId);
        bool ExisteReserva(Guid personaId, Guid eventoId);
        List<Reserva> ListarPorEvento(Guid eventoId);
        List<Reserva> ListarPorPersona(Guid personaId);
    }
}
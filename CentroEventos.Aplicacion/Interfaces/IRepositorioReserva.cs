using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Interfaces
{
    public interface IRepositorioReserva
    {
        Reserva? BuscarPorId(Guid id);
        void Agregar(Reserva reserva);
        void Modificar(Reserva reserva);
        void Eliminar(Reserva reserva);
        List<Reserva> Listar();
        int ContarPorEvento(Guid eventoId);
        bool ExisteReserva(Guid personaId, Guid eventoId);
        void GuardarCambios();
        List<Reserva> ListarPorEvento(Guid eventoId);
        List<Reserva> ListarPorPersona(Guid personaId);
        bool BuscarPersonaPorReserva(Guid personaId);
    }
}
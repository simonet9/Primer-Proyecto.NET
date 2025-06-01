using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Interfaces
{
    public interface IRepositorioReserva
    {
        Reserva? BuscarPorId(int id);
        void Agregar(Reserva reserva);
        void Modificar(Reserva reserva);
        void Eliminar(int id);
        List<Reserva> Listar();
        int ContarPorEvento(int eventoId);
        bool ExisteReserva(int personaId, int eventoId);
        List<Reserva> ListarPorEvento(int eventoId);
        List<Reserva> ListarPorPersona(int personaId);
    }
}

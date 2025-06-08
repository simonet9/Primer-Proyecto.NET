using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.UseCases.Reservas
{
    public class ListarReservasUseCase(
        IRepositorioReserva repoReserva
        )
    {
        public List<Reserva> Ejecutar()
        {
            var reservas = repoReserva.Listar();
            return ValidadorListas.ValidarNoVacia(reservas, "No hay reservas registradas.");
        }
    }
}
using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;

namespace CentroEventos.Aplicacion.Validators
{
    public static class ValidadorEventoDeportivo
    {
        public static void Validar(EventoDeportivo evento)
        {
            if (string.IsNullOrWhiteSpace(evento.Nombre))
                throw new ValidacionExcepcion("El nombre del evento no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(evento.Description))
                throw new ValidacionExcepcion("La descripción no puede estar vacía.");

            if (evento.FechaHoraInicio < DateTime.Now.Date)
                throw new ValidacionExcepcion("La fecha y hora de inicio debe ser futura o igual al presente.");

            if (evento.CupoMaximo <= 0)
                throw new ValidacionExcepcion("El cupo máximo debe ser mayor que cero.");

            if (evento.DurationHoras <= 0)
                throw new ValidacionExcepcion("La duración debe ser mayor que cero.");
        }
    }
}
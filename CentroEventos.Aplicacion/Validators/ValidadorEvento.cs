using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validators
{
    public class ValidadorEventoDeportivo(IRepositorioPersona repoPersona)
    {
        private readonly IRepositorioPersona _repoPersona = repoPersona;

        public void Validar(EventoDeportivo evento)
        {
            if (string.IsNullOrWhiteSpace(evento.Nombre))
                throw new ValidacionExcepcion("El nombre del evento no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(evento.Descripcion))
                throw new ValidacionExcepcion("La descripción no puede estar vacía.");

            if (evento.FechaHoraInicio < DateTime.Now)
                throw new ValidacionExcepcion("La fecha y hora de inicio debe ser futura o igual al presente.");

            if (evento.CupoMaximo <= 0)
                throw new ValidacionExcepcion("El cupo máximo debe ser mayor que cero.");

            if (evento.DuracionHoras <= 0)
                throw new ValidacionExcepcion("La duración debe ser mayor que cero.");

            if (_repoPersona.BuscarPorId(evento.ResponsableId) == null)
                throw new EntidadNotFoundException("El responsable indicado no existe.");
        }
    }
}
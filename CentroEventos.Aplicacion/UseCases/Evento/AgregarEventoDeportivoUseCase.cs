using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.UseCases.Evento
{
    public class AgregarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo, IServicioAutorizacion aut)
    : UseCaseConAutorizacion(aut)
    {
        public void Ejecutar(EventoDeportivo eventoDeportivo, Guid usuarioId)
        {
            ValidarAutorizacion(usuarioId, Permiso.EventoAlta);
            ValidadorEventoDeportivo.Validar(eventoDeportivo);
            if(repo.BuscarPorId(eventoDeportivo.Id) != null)
                throw new OperacionInvalidaException("Ya existe un evento deportivo con el mismo ID.");

            repo.Agregar(eventoDeportivo);
            repo.GuardarCambios();
        }
    }
}

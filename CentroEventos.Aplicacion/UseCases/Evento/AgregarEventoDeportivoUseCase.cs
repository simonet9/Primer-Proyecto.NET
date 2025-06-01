using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.UseCases.Evento
{
    public class AgregarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo, ValidadorEventoDeportivo validador, IServicioAutorizacion aut)
    {
        private readonly IRepositorioEventoDeportivo _repositorio = repo;
        private readonly ValidadorEventoDeportivo _validador = validador;
        private readonly IServicioAutorizacion _servicioAutorizacion = aut;

        public void Ejecutar(EventoDeportivo eventoDeportivo, Guid usuarioId)
        {
            VerificarAutorizacion(usuarioId);
            _validador.Validar(eventoDeportivo);
            _repositorio.Agregar(eventoDeportivo);
        }

        private void VerificarAutorizacion(Guid usuarioId)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.EventoAlta))
            {
                throw new FalloAutorizacionException();
            }
        }
    }
}

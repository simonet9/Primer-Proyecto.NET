using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso.Evento
{
    public class EliminarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo, IServicioAutorizacion aut, IRepositorioReserva repoReserva)
    {
        private readonly IRepositorioEventoDeportivo _repo = repo;
        private readonly IServicioAutorizacion _aut = aut;
        private readonly IRepositorioReserva _repoReserva = repoReserva;

        public void Ejecutar(EventoDeportivo evento, int idUsuario)
        {
            if (!_aut.PoseeElPermiso(idUsuario, permiso: Permiso.EventoBaja))
            {
                throw new FalloAutorizacionException();
            }

            if (_repoReserva.ContarPorEvento(evento.Id) > 0)
            {
                throw new OperacionInvalidaException("Existen reservas asignadas al evento");
            }

            _repo.Eliminar(evento.Id);
        }
    }
}

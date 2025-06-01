using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.CasosDeUso.Personas
{
    public class EliminarPersonaUseCase(IRepositorioPersona repo, IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva, IServicioAutorizacion aut)
    {
        private readonly IRepositorioPersona _repo = repo;
        private readonly IRepositorioEventoDeportivo _repoEvento = repoEvento;
        private readonly IRepositorioReserva _repoReserva = repoReserva;
        private readonly IServicioAutorizacion _aut = aut;

        public void Ejecutar(int idPersona, int idUsuario)
        {
            if (!_aut.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja))
                throw new FalloAutorizacionException();

            List<Reserva> reservas = _repoReserva.ListarPorPersona(idPersona);
            bool tieneEventos = _repoEvento.ExisteEventoConResponsable(idPersona);

            if (tieneEventos || reservas.Count > 0)
                throw new OperacionInvalidaException("La persona tiene eventos o reservas asociadas.");
            _repo.Eliminar(idPersona);
        }
    }
}

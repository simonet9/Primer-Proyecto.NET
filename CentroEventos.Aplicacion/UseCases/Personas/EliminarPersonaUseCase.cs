using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Personas
{
    public class EliminarPersonaUseCase(IRepositorioPersona repo, IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva, IServicioAutorizacion aut)
    {
        private readonly IRepositorioPersona _repo = repo;
        private readonly IRepositorioEventoDeportivo _repoEvento = repoEvento;
        private readonly IRepositorioReserva _repoReserva = repoReserva;
        private readonly IServicioAutorizacion _aut = aut;

        public void Ejecutar(Guid idPersona, Guid idUsuario)
        {
            VerificarAutorizacion(idUsuario);
            ValidarAsociaciones(idPersona);
            _repo.Eliminar(idPersona);
        }

        private void VerificarAutorizacion(Guid idUsuario)
        {
            if (!_aut.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja))
                throw new FalloAutorizacionException();
        }

        private void ValidarAsociaciones(Guid idPersona)
        {
            if (_repoEvento.ExisteEventoConResponsable(idPersona) || _repoReserva.ListarPorPersona(idPersona).Count > 0)
                throw new OperacionInvalidaException("La persona tiene eventos o reservas asociadas.");
        } 
    }
}

using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.CasosDeUso.Evento
{
    public class ModificarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo, ValidadorEventoDeportivo validador, IServicioAutorizacion aut)
    {
        private readonly IRepositorioEventoDeportivo _repo = repo;
        private readonly ValidadorEventoDeportivo validador = validador;
        private readonly IServicioAutorizacion aut = aut;

        public void Ejecutar(EventoDeportivo evento, int idUsuario)
        {
            if (!aut.PoseeElPermiso(idUsuario, permiso: Permiso.EventoModificacion))
            {
                throw new FalloAutorizacionException("No posee los permisos para realizar la operación");
            }
            validador.Validar(evento); //logica de negocio implementada en el validador
            _repo.Modificar(evento);
        }
    }
}

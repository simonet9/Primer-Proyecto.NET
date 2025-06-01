using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.CasosDeUso.Personas
{
    public class ModificarPersonaUseCase(IRepositorioPersona repo, ValidadorPersona validador, IServicioAutorizacion aut)
    {
        private readonly IRepositorioPersona _repo = repo;
        private readonly ValidadorPersona validador = validador;
        private readonly IServicioAutorizacion _aut = aut;

        public void Ejecutar(Persona persona, int idUsuario)
        {
            if (!_aut.PoseeElPermiso(idUsuario, Permiso.UsuarioModificacion))
                throw new FalloAutorizacionException();
            validador.Validar(persona);
            _repo.Modificar(persona);
        }
    }
}

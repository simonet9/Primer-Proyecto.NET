using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.UseCases.Personas
{
    public class AgregarPersonaUseCase(IRepositorioPersona repo, ValidadorPersona validador, IServicioAutorizacion aut)
    {
        private readonly IRepositorioPersona _repo = repo;
        private readonly ValidadorPersona _validador = validador;
        private readonly IServicioAutorizacion _aut = aut;
        public void Ejecutar(Persona persona, Guid idUsuario)
        {
            VerificarAutorizacion(idUsuario);
            _validador.Validar(persona);
            _repo.Agregar(persona);
        }
        private void VerificarAutorizacion(Guid idUsuario)
        {
            if (!_aut.PoseeElPermiso(idUsuario, Permiso.UsuarioAlta))
            {
                throw new FalloAutorizacionException();
            }
        }

    }
}

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
        public void Ejecutar(Persona persona)
        {
            VerificarAutorizacion(new Guid("00000000-0000-0000-0000-000000000001")); // Reemplazar con el ID del usuario actual
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

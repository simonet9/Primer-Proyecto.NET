using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;

namespace CentroEventos.Aplicacion.UseCases.Evento
{
    public class ModificarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo, IServicioAutorizacion aut)
    : UseCaseConAutorizacion(aut)
    {
        public void Ejecutar(EventoDeportivo evento, Guid idUsuario)
        {
            ValidarAutorizacion(idUsuario, Permiso.EventoModificacion);
            ValidadorEventoDeportivo.Validar(evento);
            repo.Modificar(evento);
            repo.GuardarCambios();
        }
    }
}

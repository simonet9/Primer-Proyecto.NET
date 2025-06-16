﻿using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators;
using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.UseCases.Users;

public class ModificarUsuarioUseCase(
    IRepositorioUsuario repoUsuario,
    IServicioAutorizacion auth)
    : UseCaseConAutorizacion(auth)
{
    public void Ejecutar(Usuario usuario, Guid usuarioModificadorId)
    {
        ValidarAutorizacion(usuarioModificadorId, Permiso.UsuarioModificacion);
        ValidadorUsuario.Validar(usuario.Nombre, usuario.Apellido, usuario.HashPassword, usuario.Email);
        repoUsuario.Actualizar(usuario);
        repoUsuario.GuardarCambios();
    }
}
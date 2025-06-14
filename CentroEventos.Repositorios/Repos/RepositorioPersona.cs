﻿using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.Data;

namespace CentroEventos.Repositorios.Repos;

public class RepositorioPersona(MyContext context) : IRepositorioPersona
{
    public void Agregar(Persona persona)=>context.Personas.Add(persona);        
    public Persona? BuscarPorId(Guid id) => context.Personas.FirstOrDefault(p => p.Id == id);
    public void Eliminar(Persona persona)=> context.Personas.Remove(persona);
    public void GuardarCambios() => context.SaveChanges();
    public bool ExisteDNI(string dni, Guid idIgnorado) => context.Personas.Any(p => p.DNI == dni && p.Id != idIgnorado);
    public bool ExisteEmail(string email, Guid idIgnorado) => context.Personas.Any(p => p.Email == email && p.Id != idIgnorado);
    public List<Persona> Listar() => context.Personas.ToList();
    public void Modificar(Persona persona)=> context.Personas.Update(persona);
}
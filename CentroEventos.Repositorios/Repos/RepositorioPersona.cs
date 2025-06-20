using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.Data;

namespace CentroEventos.Repositorios.Repos;

public class RepositorioPersona(MyContext context) : IRepositorioPersona
{
    public bool ObtenerPorEmail(string email) => context.Personas.Any(p => p.Email == email);
    public void Agregar(Persona persona)=>context.Personas.Add(persona);        
    public Persona? BuscarPorId(Guid id) => context.Personas.FirstOrDefault(p => p.Id == id);
    public Persona? ObtenerPorDocumento(string documento) => context.Personas.FirstOrDefault(p => p.Dni == documento || p.Email == documento);
    public void Eliminar(Persona persona)=> context.Personas.Remove(persona);
    public void GuardarCambios() => context.SaveChanges();
    public bool ExisteDni(string dni, Guid idIgnorado) => context.Personas.Any(p => p.Dni == dni && p.Id != idIgnorado);
    public bool ExisteEmail(string email, Guid idIgnorado) => context.Personas.Any(p => p.Email == email && p.Id != idIgnorado);
    public List<Persona> Listar() => context.Personas.ToList();
    public void Modificar(Persona persona)=> context.Personas.Update(persona);
}
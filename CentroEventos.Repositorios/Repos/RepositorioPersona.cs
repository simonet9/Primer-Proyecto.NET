using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CentroEventos.Repositorios.Repos
{
    public class RepositorioPersona : IRepositorioPersona
    {
        public void Agregar(Persona persona)
        {
            using var context = new MyContext();
            context.Personas.Add(persona);
            context.SaveChanges();
        }

        public Persona? BuscarPorId(int id)
        {
            using var context = new MyContext();
            return context.Personas.Find(id);
        }

        public void Eliminar(int id)
        {
            using var context = new MyContext();
            var persona = context.Personas.Find(id);
            if (persona != null)
            {
                context.Personas.Remove(persona);
                context.SaveChanges();
            }
        }

        public bool ExisteDNI(string dni, int idIgnorado)
        {
            using var context = new MyContext();
            return context.Personas.Any(p => p.DNI == dni && p.Id != idIgnorado);
        }

        public bool ExisteEmail(string email, int idIgnorado)
        {
            using var context = new MyContext();
            return context.Personas.Any(p => p.Email == email && p.Id != idIgnorado);
        }

        public List<Persona> Listar()
        {
            using var context = new MyContext();
            return context.Personas.ToList();
        }

        public void Modificar(Persona persona)
        {
            using var context = new MyContext();
            context.Personas.Update(persona);
            context.SaveChanges();
        }
    }
}
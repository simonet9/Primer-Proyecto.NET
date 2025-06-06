using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enum;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CentroEventos.Repositorios.Repos
{
    public class RepositorioReserva : IRepositorioReserva
    {
        public void Agregar(Reserva reserva)
        {
            using var context = new MyContext();
            context.Reservas.Add(reserva);
            context.SaveChanges();
        }

        public Reserva? BuscarPorId(Guid id)
        {
            using var context = new MyContext();
            return context.Reservas.Find(id);
        }

        public List<Reserva> Listar()
        {
            using var context = new MyContext();
            return context.Reservas.ToList();
        }

        public void Modificar(Reserva reserva)
        {
            using var context = new MyContext();
            context.Reservas.Update(reserva);
            context.SaveChanges();
        }

        public void Eliminar(Guid id)
        {
            using var context = new MyContext();
            var reserva = context.Reservas.Find(id);
            if (reserva == null) return;
            context.Reservas.Remove(reserva);
            context.SaveChanges();
        }

        public int ContarPorEvento(Guid eventoId)
        {
            using var context = new MyContext();
            return context.Reservas.Count(r => r.EventoDeportivoId == eventoId);
        }

        public bool ExisteReserva(Guid personaId, Guid eventoId)
        {
            using var context = new MyContext();
            return context.Reservas.Any(r => r.PersonaId == personaId && r.EventoDeportivoId == eventoId);
        }

        public List<Reserva> ListarPorEvento(Guid eventoId)
        {
            using var context = new MyContext();
            return context.Reservas.Where(r => r.EventoDeportivoId == eventoId).ToList();
        }

        public List<Reserva> ListarPorPersona(Guid personaId)
        {
            using var context = new MyContext();
            return context.Reservas.Where(r => r.PersonaId == personaId).ToList();
        }
    }
}
using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CentroEventos.Repositorios.Repos
{
    public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
    {
        public void Agregar(EventoDeportivo evento)
        {
            using var context = new MyContext();
            context.EventosDeportivos.Add(evento);
            context.SaveChanges();
        }

        public EventoDeportivo? BuscarPorId(Guid id)
        {
            using var context = new MyContext();
            return context.EventosDeportivos.Find(id);
        }

        public List<EventoDeportivo> Listar()
        {
            using var context = new MyContext();
            return context.EventosDeportivos.ToList();
        }

        public void Modificar(EventoDeportivo evento)
        {
            using var context = new MyContext();
            context.EventosDeportivos.Update(evento);
            context.SaveChanges();
        }

        public void Eliminar(Guid id)
        {
            using var context = new MyContext();
            var evento = context.EventosDeportivos.Find(id);
            if (evento == null) return;
            context.EventosDeportivos.Remove(evento);
            context.SaveChanges();
        }

        public List<EventoDeportivo> ListarFuturosConCupoDisponible()
        {
            using var context = new MyContext();
            var ahora = DateTime.Now;
            return context.EventosDeportivos
                .Where(e => e.FechaHoraInicio > ahora && 
                            context.Reservas.Count(r => r.EventoDeportivoId == e.Id) < e.CupoMaximo)
                .ToList();
        }

        public List<EventoDeportivo> ListarPorResponsable(Guid personaId)
        {
            using var context = new MyContext();
            return context.EventosDeportivos
                .Where(e => e.ResponsableId == personaId)
                .ToList();
        }

        public bool ExisteEventoConResponsable(Guid responsableId)
        {
            using var context = new MyContext();
            return context.EventosDeportivos.Any(e => e.ResponsableId == responsableId);
        }
    }
}
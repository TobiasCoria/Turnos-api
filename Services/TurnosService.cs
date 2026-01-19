using Turnos.API.Data;
using Turnos.API.DTOs;
using Turnos.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Turnos.API.Services
{
    public class TurnosService
    {
        private readonly TurnosDbContext _context;

        public TurnosService(TurnosDbContext context)
        {
            _context = context;
        }

        public List<Turno> GetAll()
        {
            return _context.Turnos.ToList();
        }

        public Turno? GetById(int id)
        {
            return _context.Turnos.FirstOrDefault(t => t.Id == id);
        }

        public List<Turno> GetByDate(DateTime fecha)
        {
            return _context.Turnos
                .Where(t => t.Fecha.Date == fecha.Date)
                .ToList();
        }

        public Turno Create(CreateTurnoDto dto)
        {
            var turno = new Turno
            {
                Cliente = dto.Client,
                Servicio = dto.Service,
                Fecha = dto.Date,
                Estado = EstadoTurno.Pendiente
            };

            _context.Turnos.Add(turno);
            _context.SaveChanges();

            return turno;
        }

        public Turno? CambiarEstado(int id, EstadoTurno nuevoEstado)
        {
            var turno = _context.Turnos.FirstOrDefault(t => t.Id == id);
            if (turno == null)
                return null;

            if (turno.Estado == EstadoTurno.Cancelado)
                throw new Exception("No se puede modificar un turno cancelado");

            if (turno.Estado == EstadoTurno.Confirmado &&
                nuevoEstado == EstadoTurno.Pendiente)
                throw new Exception("No se puede volver a Pendiente");

            turno.Estado = nuevoEstado;
            _context.SaveChanges();

            return turno;
        }

        public bool Delete(int id)
        {
            var turno = _context.Turnos.FirstOrDefault(t => t.Id == id);
            if (turno == null)
                return false;

            _context.Turnos.Remove(turno);
            _context.SaveChanges();

            return true;
        }
    }
}




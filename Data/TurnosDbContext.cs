using Microsoft.EntityFrameworkCore;
using Turnos.API.Models;

namespace Turnos.API.Data
{
    public class TurnosDbContext : DbContext
    {
        public TurnosDbContext(DbContextOptions<TurnosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Turno> Turnos { get; set; }
    }
}

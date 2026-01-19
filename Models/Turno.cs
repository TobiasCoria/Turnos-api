namespace Turnos.API.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Servicio { get; set; } = string.Empty;
        public EstadoTurno Estado { get; set; }
    }
}

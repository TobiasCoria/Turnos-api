namespace Turnos.API.DTOs
{
    public class CreateTurnoDto
    {
        public string Client { get; set; } = null!;
        public string Service { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}





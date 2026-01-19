using Microsoft.AspNetCore.Mvc;
using Turnos.API.DTOs;
using Turnos.API.Services;

namespace Turnos.API.Controllers
{
    [ApiController]
    [Route("api/turnos")]
    public class TurnosController : ControllerBase
    {
        private readonly TurnosService _service;

        public TurnosController(TurnosService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var turno = _service.GetById(id);
            if (turno == null)
                return NotFound();

            return Ok(turno);
        }

        [HttpGet("fecha/{fecha}")]
        public IActionResult GetByDate(DateTime fecha)
        {
            return Ok(_service.GetByDate(fecha));
        }

        [HttpPost]
public IActionResult Create([FromBody] CreateTurnoDto dto)
{
    var turno = _service.Create(dto);
    return Ok(turno);
}


        [HttpPut("{id}/estado")]
        public IActionResult CambiarEstado(int id, [FromBody] CambiarEstadoTurnoDto dto)
        {
            var turno = _service.CambiarEstado(id, dto.Estado);
            if (turno == null)
                return NotFound();

            return Ok(turno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}




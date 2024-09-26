using APS_Backend.Application;
using APS_Backend.Application.Dtos.Aluno;
using APS_Backend.Application.Dtos.Evento;
using APS_Backend.Application.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace APS_Backend.Controllers
{
    [Route("api/evento")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService eventoService;

        public EventoController(IEventoService eventoService)
        {
            this.eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var _evento = await eventoService.GetAllEventoAsync();
                if (_evento == null)
                {
                    return NoContent();
                }

                return Ok(_evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var _evento = await eventoService.GetEventoByIdAsync(Id);
                if (_evento == null)
                {
                    return NoContent(); ;
                }
                return Ok(_evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }
        [HttpGet("lista/{matricula}")]
        public async Task<IActionResult> GetAllEventosByAlunoId(int matricula)
        {
            try
            {
                var _evento = await eventoService.GetAllEventosByAlunoIdAsync(matricula);
                if (_evento == null)
                {
                    return NoContent(); ;
                }
                return Ok(_evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }
        [HttpGet("concluido/{matricula_aluno}")]
        public async Task<IActionResult> GetAllEventosConcluidosByAlunoId(int matricula)
        {
            try
            {
                var _evento = await eventoService.GetAllEventosConcluidosByAlunoIdAsync(matricula);
                if (_evento == null)
                {
                    return NoContent(); ;
                }
                return Ok(_evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateEventoRequestDto model)
        {
            try
            {
                var _evento = await eventoService.AddEvento(model);
                if (_evento == null)
                {
                    return BadRequest("Aluno could not be registred");
                }
                return Ok(_evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, UpdateEventoRequestDto model)
        {
            try
            {
                var _evento = await eventoService.UpdateEvento(Id, model);
                if (_evento == null)
                {
                    return BadRequest("Evento could not be updated");
                }
                return Ok(_evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if (await eventoService.DeleteEvento(Id))
                {
                    return Ok("Deleted");
                }
                else
                {
                    return BadRequest("Evento could not be deleted");
                }

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }
    }
}

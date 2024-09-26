using APS_Backend.Application;
using APS_Backend.Application.Dtos.Evento;
using APS_Backend.Application.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace APS_Backend.Controllers
{
    [Route("api/cadastro")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroService cadastroService;

        public CadastroController(ICadastroService cadastroService)
        {
            this.cadastroService = cadastroService;
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe(int matricula, int eventoId)
        {
            try
            {
                var _cadastro = await cadastroService.SubscribeAluno(matricula, eventoId);
                if (_cadastro == false)
                {
                    return BadRequest("Aluno could not be subscribed in event");
                }
                return Ok(_cadastro);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }
        [HttpPost("unsubscribe")]
        public async Task<IActionResult> Unsubscribe(int matricula, int eventoId)
        {
            try
            {
                var _cadastro = await cadastroService.UnsubscribeAluno(matricula, eventoId);
                if (_cadastro == false)
                {
                    return BadRequest("Aluno could not be unsubscribed in event");
                }
                return Ok(_cadastro);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }
    }
}

using APS_Backend.Application;
using APS_Backend.Application.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace APS_Backend.Controllers
{
    [Route("api/presenca")]
    [ApiController]
    public class PresencaController : ControllerBase
    {

        private readonly IPresencaService presencaService;

        public PresencaController(IPresencaService presencaService)
        {
            this.presencaService = presencaService;
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> CheckOut(int eventoId, [FromBody] int[] matriculas)
        {
            try
            {
                var _presencas = await presencaService.UpdatePresenca(eventoId, matriculas);
                if (_presencas == false)
                {
                    return BadRequest("Presencas could not be registred in event");
                }
                return Ok(_presencas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }
    }
}

using APS_Backend.Application;
using APS_Backend.Application.Dtos.Aluno;
using APS_Backend.Application.Dtos.Professor;
using APS_Backend.Application.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace APS_Backend.Controllers
{
    [Route("api/professor")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService professorService;

        public ProfessorController(IProfessorService professorService)
        {
            this.professorService = professorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var _professor = await professorService.GetAllProfessorAsync();
                if (_professor == null)
                {
                    return NoContent();
                }

                return Ok(_professor);
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
                var _professor = await professorService.GetProfessorByIdAsync(Id);
                if (_professor == null)
                {
                    return NoContent(); ;
                }
                return Ok(_professor);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateProfessorRequestDto model)
        {
            try
            {
                var _professor = await professorService.AddProfessor(model);
                if (_professor == null)
                {
                    return BadRequest("Professor could not be registred");
                }
                return Ok(_professor);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, UpdateProfessorRequestDto model)
        {
            try
            {
                var _professor = await professorService.UpdateProfessor(Id, model);
                if (_professor == null)
                {
                    return BadRequest("Professor could not be updated");
                }
                return Ok(_professor);
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
                if (await professorService.DeleteProfessor(Id))
                {
                    return Ok("Deleted");
                }
                else
                {
                    return BadRequest("Professor could not be deleted");
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

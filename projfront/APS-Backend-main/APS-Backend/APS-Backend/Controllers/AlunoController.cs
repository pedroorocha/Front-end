using APS_Backend.Application;
using APS_Backend.Application.Dtos.Aluno;
using APS_Backend.Application.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace APS_Backend.Controllers
{
    [Route("api/aluno")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService alunoService;


        public AlunoController(IAlunoService alunoService)
        {
            this.alunoService = alunoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var _alunos = await alunoService.GetAllAlunosAsync();
                if (_alunos == null)
                {
                    return NoContent();
                }

                return Ok(_alunos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }

        [HttpGet("{matricula}")]
        public async Task<IActionResult> GetById(int matricula)
        {
            try
            {
                var _aluno = await alunoService.GetAlunoByIdAsync(matricula);
                if (_aluno == null)
                {
                    return NoContent(); ;
                }
                return Ok(_aluno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }
        [HttpGet("curso/{nome}")]
        public async Task<IActionResult> GetAllAlunosByCurso(string nome)
        {
            try
            {
                var _aluno = await alunoService.GetAllAlunosByCursoAsync(nome);
                if (_aluno == null)
                {
                    return NoContent(); ;
                }
                return Ok(_aluno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }
        [HttpGet("evento/{eventoId}")]
        public async Task<IActionResult> GetAllAlunosByEventoId(int eventoId)
        {
            try
            {
                var _aluno = await alunoService.GetAllAlunosByEventoIdAsync(eventoId);
                if (_aluno == null)
                {
                    return NoContent(); ;
                }
                return Ok(_aluno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }
        [HttpGet("espera/{eventoId}")]
        public async Task<IActionResult> GetAlunosEsperaByEventoId(int eventoId)
        {
            try
            {
                var _aluno = await alunoService.GetAlunosEsperaByEventoIdAsync(eventoId);
                if (_aluno == null)
                {
                    return NoContent(); ;
                }
                return Ok(_aluno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAlunoRequestDto model)
        {
            try
            {
                var _aluno = await alunoService.AddAluno(model);
                if (_aluno == null)
                {
                    return BadRequest("Aluno could not be registred");
                }
                return Ok(_aluno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }

        [HttpPut("{matricula}")]
        public async Task<IActionResult> Put(int matricula, UpdateAlunoRequestDto model)
        {
            try
            {
                var _aluno = await alunoService.UpdateAluno(matricula, model);
                if (_aluno == null)
                {
                    return BadRequest("Aluno could not be updated");
                }
                return Ok(_aluno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while trying to find data. Error: {ex.Message}");
            }
        }

        [HttpDelete("{matricula}")]
        public async Task<IActionResult> Delete(int matricula)
        {
            try
            {
                if (await alunoService.DeleteAluno(matricula))
                {
                    return Ok("Deleted");
                }
                else
                {
                    return BadRequest("Aluno could not be deleted");
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

using Microsoft.AspNetCore.Mvc;
using TarefasAPI.Exceptions;
using TarefasAPI.Models;
using TarefasAPI.Services;

namespace TarefasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _service;

        public TarefasController(ITarefaService service)
        {
            _service = service;
        }

        [HttpPost("AdicionarTarefa")]
        public async Task<IActionResult> AdicionarTarefa([FromBody] Tarefa tarefa)
        {
            try
            {
                await _service.AddAsync(tarefa);
                return Ok(tarefa);
            }
            catch (TarefaException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpGet("ListarTarefasPendentes")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> ListarTarefasPendentes()
        {
            var tarefas = await _service.GetPendingAsync();
            return Ok(tarefas);
        }

        [HttpDelete("RemoverTarefa/{id}")]
        public async Task<IActionResult> RemoverTarefa(int id)
        {
            await _service.RemoveAsync(id);
            return NoContent();
        }

        [HttpPut("MarcarTarefaComoConcluida/{id}")]
        public async Task<IActionResult> MarcarTarefaComoConcluida(int id)
        {
            await _service.MarkAsCompletedAsync(id);
            return NoContent();
        }

        [HttpGet("FiltrarTarefasConcluidas")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> FiltrarTarefasConcluidas()
        {
            var tarefas = await _service.GetCompletedAsync();
            return Ok(tarefas);
        }

        [HttpGet("ListarTarefas")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> ListarTarefas()
        {
            var tarefas = await _service.GetAllAsync();
            return Ok(tarefas);
        }
    }
}

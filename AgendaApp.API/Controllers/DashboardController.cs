using AgendaApp.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.Api.Controllers
{
    [Route("api/v1/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        [HttpGet("tarefas-prioridade/{dataHoraMin}/{dataHoraMax}")]
        public IActionResult GetTarefasPrioridade(DateTime dataHoraMin, DateTime dataHoraMax)
        {
            var tarefaRepository = new TarefaRepository();

            var dados = tarefaRepository.ObterTarefasPorPrioridade(dataHoraMin, dataHoraMax);

            return Ok(dados);
        }

        [HttpGet("tarefas-categoria/{dataHoraMin}/{dataHoraMax}")]
        public IActionResult GetTarefasCategoria(DateTime dataHoraMin, DateTime dataHoraMax)
        {
            var tarefaRepository = new TarefaRepository();

            var dados = tarefaRepository.ObterTarefasPorCategoria(dataHoraMin, dataHoraMax);

            return Ok(dados);
        }
    }
}

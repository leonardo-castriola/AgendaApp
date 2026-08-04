using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        //Serviço para cadastro de tarefas
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        //Serviço para atualização de tarefas
        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        //Serviço para exclusão de tarefas
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

    }
}

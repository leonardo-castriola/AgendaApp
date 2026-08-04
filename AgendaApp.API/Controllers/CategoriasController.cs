using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        //Serviço para consulta de categorias
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}

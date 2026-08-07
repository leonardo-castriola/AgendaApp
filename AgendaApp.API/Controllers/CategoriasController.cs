using AgendaApp.Api.Dtos;
using AgendaApp.Domain.Entities;
using AgendaApp.Infra.Data.Mappings;
using AgendaApp.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.Api.Controllers
{
    [Route("api/v1/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        //Serviço para consulta de categorias
        [HttpGet]
        public IActionResult Get()
        {
            //Consultando todas as categorias no banco de dados
            var categoriaRepository = new CategoriaRepository();
            var categorias = categoriaRepository.ObterTodos();

            //Copiando os dados da entidade para o DTO
            var response = categorias.Select(c => ToResponse(c)).ToList();

            //Retornando os dados
            return Ok(response);
        }

        //Método auxiliar para copiar os dados da
        //classe de entidade para o dto (record)
        private CategoriaResponse ToResponse(Categoria categoria)
        {
            return new CategoriaResponse(
                    categoria.Id,
                    categoria.Descricao
                );
        }
    }
}

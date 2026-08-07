using AgendaApp.Api.Dtos;
using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Enums;
using AgendaApp.Infra.Data.Repositories;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.Api.Controllers
{
    [Route("api/v1/tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        //Serviço para cadastro de tarefas
        [HttpPost]
        public IActionResult Post(TarefaRequest request)
        {
            var tarefa = new Tarefa()
            {
                Nome = request.nome,
                DataHoraInicio = request.dataHoraInicio,
                DataHoraFim = request.dataHoraFim,
                Prioridade = (Prioridade)request.prioridade,
                CategoriaId = request.categoriaId,
            };

            var tarefaRepository = new TarefaRepository();
            tarefaRepository.Adicionar(tarefa);

            return Ok(new
            {
                mensagem = "Tarefa cadastrada com sucesso.",
                dataHora = DateTime.Now,
                id = tarefa.Id,
            });
        }

        //Serviço para atualização de tarefas
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TarefaRequest request)
        {
            var tarefa = new Tarefa()
            {
                Id = id,
                Nome = request.nome,
                DataHoraInicio = request.dataHoraInicio,
                DataHoraFim = request.dataHoraFim,
                Prioridade = (Prioridade)request.prioridade,
                CategoriaId = request.categoriaId,
            };

            var tarefaRepository = new TarefaRepository();
            tarefaRepository.Alterar(tarefa);

            return Ok(new
            {
                mensagem = "Tarefa atualizada com sucesso.",
                dataHora = DateTime.Now,
                id = tarefa.Id,
            });
        }

        //Serviço para exclusão de tarefas
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var tarefa = new Tarefa()
            {
                Id = id,
            };

            var tarefaRepository = new TarefaRepository();
            tarefaRepository.Excluir(tarefa);

            return Ok(new
            {
                mensagem = "Tarefa excluída com sucesso.",
                dataHora = DateTime.Now,
                id = tarefa.Id,
            });
        }

        //Serviço para consultade tarefas
        [HttpGet("{dataHoraMin}/{dataHoraMax}")]
        public IActionResult Get(DateTime dataHoraMin, DateTime dataHoraMax)
        {
            var tarefaRepository = new TarefaRepository();
            var tarefas = tarefaRepository.ObterPorDatas(dataHoraMin, dataHoraMax);

            var response = tarefas.Select(t => ToResponse(t)).ToList();

            return Ok(response);
        }

        //Método para copiar os dados da entidade
        //Tarefa para o DTO TarefaResponse
        private TarefaResponse ToResponse(Tarefa tarefa)
        {
            return new TarefaResponse(
                    tarefa.Id,
                    tarefa.Nome,
                    tarefa.DataHoraInicio,
                    tarefa.DataHoraFim,
                    tarefa.Prioridade.ToString(),
                    tarefa.Categoria!.Descricao
                );
        }
    }
}

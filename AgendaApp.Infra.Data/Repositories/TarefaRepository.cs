using AgendaApp.Domain.Entities;
using AgendaApp.Infra.Data.Contexts;
using AgendaApp.Infra.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp.Infra.Data.Repositories
{
    public class TarefaRepository
    {
        //Método para inserir uma tarefa no banco de dados
        public void Adicionar(Tarefa tarefa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Set<Tarefa>().Add(tarefa);
                dataContext.SaveChanges();
            }
        }

        //Método para alterar uma tarefa no banco de dados
        public void Alterar(Tarefa tarefa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Set<Tarefa>().Update(tarefa);
                dataContext.SaveChanges();
            }
        }

        //Método para excluir uma tarefa no banco de dados
        public void Excluir(Tarefa tarefa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Set<Tarefa>().Remove(tarefa);
                dataContext.SaveChanges();
            }
        }

        //Método para consultar as tarefas no banco de dados
        //Dentro de um periodo de datas informado
        public List<Tarefa> ObterPorDatas(DateTime dataHoraMin, DateTime dataHoraMax)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Tarefa>()
                            .Include(t => t.Categoria)
                            .Where(t => t.DataHoraInicio >= dataHoraMin
                                     && t.DataHoraInicio <= dataHoraMax)
                            .OrderBy(t => t.DataHoraInicio)
                            .ToList();
            }
        }

        //Método para consultar 1 tarefa no banco de dados
        //baseado no ID informado
        public Tarefa? ObterPorId(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Tarefa>()
                        .Include(t => t.Categoria)
                        .Where(t => t.Id == id)
                        .FirstOrDefault();
            }
        }

        //Método para retornar a quantidade de tarefas cadastradas
        //por prioridade dentro de um periodo de datas informado.
        public List<QtdTarefasPrioridadeModel> ObterTarefasPorPrioridade(
                DateTime dataHoraInicio,
                DateTime dataHoraFim
            )
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Tarefa>() //Consulta de tarefas
                        .Where(t => t.DataHoraInicio >= dataHoraInicio //Filtro por data
                                 && t.DataHoraFim <= dataHoraFim) //Filtro por data
                        .GroupBy(t => t.Prioridade) //Agrupar / totalizar por prioridade
                        .Select(g => new QtdTarefasPrioridadeModel
                        {
                            Prioridade = g.Key.ToString(), //Nome da prioridade
                            QuantidadeTarefas = g.Count() //Quantidade das tarefas
                        })
                        .OrderByDescending(g => g.QuantidadeTarefas) //Ordenação
                        .ToList(); //Retornar a lista com os dados
            }
        }

        //Método para retornar a quantidade de tarefas cadastradas
        //por categoria dentro de um periodo de datas informado
        public List<QtdTarefasCategoriaModel> ObterTarefasPorCategoria(
                DateTime dataHoraInicio,
                DateTime dataHoraFim
            )
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Tarefa>() //Consulta de tarefas
                        .Include(t => t.Categoria) //JOIN com a tabela de Categoria
                        .Where(t => t.DataHoraInicio >= dataHoraInicio //Filtro por data
                                 && t.DataHoraFim <= dataHoraFim) //Filtro por data
                        .GroupBy(t => t.Categoria!.Descricao) //Agrupar / totalizar pela categoria
                        .Select(g => new QtdTarefasCategoriaModel
                        {
                            NomeCategoria = g.Key.ToString(), //Descrição da categoria
                            QuantidadeTarefas = g.Count() //Quantidade das tarefas
                        })
                        .OrderByDescending(g => g.QuantidadeTarefas) //Ordenação
                        .ToList(); //Retornar a lista com os dados
            }
        }
    }
}

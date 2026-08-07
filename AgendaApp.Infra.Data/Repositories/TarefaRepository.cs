using AgendaApp.Domain.Entities;
using AgendaApp.Infra.Data.Contexts;
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

    }
}

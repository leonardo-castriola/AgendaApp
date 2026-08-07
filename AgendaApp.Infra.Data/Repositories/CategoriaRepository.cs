using AgendaApp.Domain.Entities;
using AgendaApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp.Infra.Data.Repositories
{
    public class CategoriaRepository
    {
        //Método para consultar todas as categorias do banco de dados
        public List<Categoria> ObterTodos()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Categoria>()
                            .OrderBy(c => c.Descricao)
                            .ToList();
            }
        }
    }
}

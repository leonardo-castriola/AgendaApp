using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp.Domain.Entities
{
    public class Categoria
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Descricao { get; set; } = string.Empty;
        public List<Tarefa>? Tarefas { get; set; }
    }
}

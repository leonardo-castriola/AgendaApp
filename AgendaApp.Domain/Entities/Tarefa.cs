using AgendaApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp.Domain.Entities
{
    public class Tarefa
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public Prioridade Prioridade { get; set; }
        public Guid CategoriaId { get; set; } //Chave estrangeira

        //Relacionamento
        public Categoria? Categoria { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp.Infra.Data.Models
{
    public class QtdTarefasPrioridadeModel
    {
        public string Prioridade { get; set; } = string.Empty;
        public int QuantidadeTarefas { get; set; } = 0;
    }
}

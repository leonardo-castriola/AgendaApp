using AgendaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp.Infra.Data.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            //Chave primária
            builder.HasKey(t => t.Id);

            //Relacionamento de 1 para muitos
            builder.HasOne(t => t.Categoria) //Tarefa TEM 1 Categoria
                .WithMany(c => c.Tarefas) //Categoria TEM MUITAS Tarefas
                .HasForeignKey(t => t.CategoriaId); //Chave estrangeira
        }
    }
}

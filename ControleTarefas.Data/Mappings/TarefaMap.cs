using ControleTarefas.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Data.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefa");

            builder.HasKey(x => x.CodTarefa);

            builder.Property(x => x.CodTarefa)
               .ValueGeneratedOnAdd()
               .UseIdentityColumn();

            builder.Property(x => x.Titulo)
                        .IsRequired()
                        .HasColumnName("Titulo")
                        .HasColumnType("NVARCHAR")
                        .HasMaxLength(80);

            builder.Property(x => x.Descricao)
                      .IsRequired()
                      .HasColumnName("Descricao")
                      .HasColumnType("NVARCHAR")
                      .HasMaxLength(250);

            builder
              .HasIndex(x => x.CodTarefa, "I_Tarefa_CodTarefa")
              .IsUnique();


        }
    }
}

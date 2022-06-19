using ControleTarefas.Business.Models;
using ControleTarefas.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using static ControleTarefas.Data.Helpers.Enums;

namespace ControleTarefas.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
             : base(options)
        {

        }

        public DbSet<Tarefa> Tarefa { get; set; }
        public DbSet<TarefaPrioridade> TarefaPrioridade { get; set; }
        public DbSet<TarefaStatus> TarefasStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMap());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataInsercao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataInsercao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataInsercao").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CodTarefaStatus") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CodTarefaStatus").CurrentValue = (int)TarefaStatusEnum.Backlog;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}

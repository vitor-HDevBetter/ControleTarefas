using ControleTarefas.Business.Intefaces.IRepositories;
using ControleTarefas.Business.Intefaces.IServices;
using ControleTarefas.Business.Notificacoes;
using ControleTarefas.Business.Services;
using ControleTarefas.Data.Context;
using ControleTarefas.Data.Repository;

namespace ControleTarefas.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();

            //REPO
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<ITarefaPrioridadeRepository, TarefaPrioridadeRepository>();
            services.AddScoped<ITarefaStatusRepository, TarefaStatusRepository>();

            //SERVICES
            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}

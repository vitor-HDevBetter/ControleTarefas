
using AutoMapper;
using ControleTarefas.Business.Models;
using ControleTarefas.Models;
using ControleTarefas.ViewModels;

namespace ControleTarefas.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Tarefa, TarefaViewModel>().ReverseMap();
            CreateMap<TarefaPrioridade, TarefaPrioridadeViewModel>().ReverseMap();
            CreateMap<TarefaStatus, TarefasStatusViewModel>().ReverseMap();
        }
    }
}

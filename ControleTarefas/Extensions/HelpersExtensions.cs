using ControleTarefas.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ControleTarefas.Extensions
{
    public static class HelpersExtensions
    {
        public static string ObterErrosModelState(this ModelStateDictionary modelState)
        {
            var result = "";

            foreach (var item in modelState.Values)
            {
                var value = item.Errors.Select(x => x.ErrorMessage).FirstOrDefault();

                if (value != null)
                    result += value + ", ";
            }

            result = result.Remove(result.Length - 2);

            return result;
        }

        public static string ObterErrosNotificacoes(List<Notificacao> notificacoes)
        {
            var result = "";

            foreach (var item in notificacoes)
                result += item.Mensagem + ", ";

            result = result.Remove(result.Length - 2);

            return result;
        }

        public static string MostrarData(DateTime? data, string format = "dd MMMM yyyy")
        {
            return data.HasValue ? data.Value.ToString(format) : "-";
        }
        
    }
}

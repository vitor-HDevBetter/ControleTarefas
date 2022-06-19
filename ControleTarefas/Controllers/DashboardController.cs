using Microsoft.AspNetCore.Mvc;

namespace ControleTarefas.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

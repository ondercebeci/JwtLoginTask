using Microsoft.AspNetCore.Mvc;

namespace TaskCostummerSupport.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

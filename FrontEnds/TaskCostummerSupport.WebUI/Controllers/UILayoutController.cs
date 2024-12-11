using Microsoft.AspNetCore.Mvc;

namespace TaskCostummerSupport.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

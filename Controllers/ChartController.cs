using Microsoft.AspNetCore.Mvc;

namespace TruckAssistant.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

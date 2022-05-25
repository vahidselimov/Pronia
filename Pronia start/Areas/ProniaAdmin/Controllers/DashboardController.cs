using Microsoft.AspNetCore.Mvc;

namespace Pronia_start.Areas.ProniaAdmin.Controllers
{
    public class DashboardController : Controller
    {
        [Area("ProniaAdmin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

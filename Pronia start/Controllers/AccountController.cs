using Microsoft.AspNetCore.Mvc;
using Pronia_start.ViewModels;
using System.Threading.Tasks;

namespace Pronia_start.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            return View();
        }
    }
}

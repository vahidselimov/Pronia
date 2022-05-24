using Microsoft.AspNetCore.Mvc;
using Pronia_start.DAL;
using Pronia_start.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pronia_start.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context;

        public HomeController(AppDbContext context)
        {
            this.context = context;
        }

      
        public IActionResult Index()
        {
            List<Slider> sliders = context.Sliders.ToList();
            return View(sliders);
        }
    }
}

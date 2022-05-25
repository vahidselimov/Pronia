using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_start.DAL;
using Pronia_start.Models;
using Pronia_start.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pronia_start.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context;

        public HomeController(AppDbContext context)
        {
            this.context = context;
        }


        public async Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM
            {
                Sliders = await context.Sliders.ToListAsync(),
                Plants = await context.Plants.Include(p => p.PlantImages).ToListAsync()
            };
            return View(model);
        }
    }
}

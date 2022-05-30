using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_start.DAL;
using Pronia_start.Extensions;
using Pronia_start.Models;
using Pronia_start.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pronia_start.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class PlantController : Controller
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHost;

        public PlantController(AppDbContext context,IWebHostEnvironment webHost)

        {
            this.context = context;
            this.webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {
            List<Plant> plants = await context.Plants.Include(p=>p.PlantImages).ToListAsync();
            return View(plants);
        }
        public async Task <IActionResult> Create()
        {
            ViewBag.Sizes = await context.Sizes.ToListAsync();
            ViewBag.Colors = await context.Colors.ToListAsync();
            return View();

           
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult>Create(Plant plant)
        {
            ViewBag.Sizes = await context.Sizes.ToListAsync();
            ViewBag.Colors = await context.Colors.ToListAsync();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (plant.MainImage==null||plant.AnotherImage==null)
            {
                ModelState.AddModelError("", "Please enter photo");
                return View();

            }
            if (!plant.MainImage.IsOkay(1))
            {
                ModelState.AddModelError("MainImage", "Please choose IMage");
            }
            foreach (var image in plant.AnotherImage)
            {
                if (!image.IsOkay(1))
                {
                    ModelState.AddModelError("AnotherImage", "Please choose AnotherImage IMage");
                }

            }
            plant.PlantImages = new List<PlantImage>();
            PlantImage plantImage = new PlantImage
            {
                ImagePath = await plant.MainImage.FileCreate(webHost.WebRootPath, @"assets/images/website-images"),
                IsMain = true,
                Plant=plant
            };
            plant.PlantImages.Add(plantImage);
            foreach (var image in plant.AnotherImage)
            {
                PlantImage plantImage1 = new PlantImage
                {
                    ImagePath = await image.FileCreate(webHost.WebRootPath, @"assets/images/website-images"),
                    IsMain = false,
                    Plant = plant
                };
                plant.PlantImages.Add(plantImage1);
            }
            await context.Plants.AddAsync(plant);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

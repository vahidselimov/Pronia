using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_start.DAL;
using Pronia_start.Extensions;
using Pronia_start.Models;
using Pronia_start.Utilities;
using System.Collections.Generic;
using System.Linq;
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
            ViewBag.Categories = await context.Categories.ToListAsync();
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
        public async Task<IActionResult> Detail(int id)
        {
           Plant plant = await context.Plants.Include(p=>p.PlantImages).FirstOrDefaultAsync(c => c.Id == id);
            if (plant == null) return NotFound();
            return View(plant);

        }
        public async Task<IActionResult> Delete(int id)
        {
           Plant plant = await context.Plants.FirstOrDefaultAsync(c => c.Id == id);
            
            if (plant == null) return NotFound();
            return View(plant);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSize(int id)
        {
            Plant plant = await context.Plants.FirstOrDefaultAsync(c => c.Id == id);
            Plant plant1 = await context.Plants.Include(p => p.PlantImages).FirstOrDefaultAsync(c => c.Id == id);
            if (plant == null) return NotFound();
            if (plant1 == null) return NotFound();
            
            context.Plants.Remove(plant);
            context.Plants.Remove(plant1);


            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Edit(int id)
        {
            ViewBag.Sizes = await context.Sizes.ToListAsync();
            ViewBag.Colors = await context.Colors.ToListAsync();
            ViewBag.Categories = await context.Categories.ToListAsync();


            Plant plant = await context.Plants.Include(p=>p.PlantImages).FirstOrDefaultAsync(c => c.Id == id);
            if (plant == null) return NotFound();
           
            return View(plant);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Plant plant)
        {
            ViewBag.Sizes = await context.Sizes.ToListAsync();
            ViewBag.Colors = await context.Colors.ToListAsync();
            ViewBag.Categories = await context.Categories.ToListAsync();
            Plant existed = await context.Plants.Include(p => p.PlantImages).Include(p => p.PlantCategories).FirstOrDefaultAsync(p => p.Id == id);
            
            if (existed == null) return NotFound();
           
            if (plant.ImageIds==null&& plant.Imgmainid==null)
            {
                ModelState.AddModelError("", "One of Ismain or Anotherimage is null");
                return View();
            }

            if (plant.Imgmainid==null && plant.MainImage==null)
            {
                ModelState.AddModelError("", "You can not delete all images without adding another image");
                return View(existed);
            }
            if (plant.ImageIds == null && plant.AnotherImage == null)
            {
                ModelState.AddModelError("", "You can not delete all images without adding another image");
                return View(existed);
            }

            List<PlantImage> removableImages = existed.PlantImages.Where(p => p.IsMain == false && !plant.ImageIds.Contains(p.Id)).ToList();
            List<PlantImage> removableImages1 = existed.PlantImages.Where(p => p.IsMain == true && plant.Imgmainid != p.Id).ToList();

            existed.PlantImages.RemoveAll(p => removableImages.Any(ri => ri.Id == p.Id));

           existed.PlantImages.RemoveAll(p => removableImages1.Any(ri => ri.Id == p.Id));

            List<PlantCategory> removableCategories = existed.PlantCategories.Where(pc => !plant.CategoryIds.Contains(pc.CategoryId)).ToList();

            existed.PlantCategories.RemoveAll(pc => removableCategories.Any(rc => rc.Id == pc.Id));

            foreach (var item in plant.CategoryIds)
            {

                PlantCategory existedCategory = existed.PlantCategories.FirstOrDefault(pc => pc.CategoryId == item);
                if (existedCategory == null)
                {
                    PlantCategory plantCategory = new PlantCategory
                    {
                        PlantId = existed.Id,
                        CategoryId = item
                    };
                    existed.PlantCategories.Add(plantCategory);
                }
            }

            foreach (var image in removableImages)
            {
                FileUtilities.FileDelete(webHost.WebRootPath, @"assets\images\website-images", image.ImagePath);
            }
            foreach (var image in removableImages1)
            {
                FileUtilities.FileDelete(webHost.WebRootPath, @"assets\images\website-images", image.ImagePath);
            }

            if (plant.AnotherImage != null)
            {
                foreach (var image in plant.AnotherImage)
                {
                    PlantImage plantImage = new PlantImage
                    {
                        ImagePath = await image.FileCreate(webHost.WebRootPath, @"assets\images\website-images"),
                        IsMain = false,
                        PlantId = existed.Id
                    };
                    existed.PlantImages.Add(plantImage);
                }
            }
            if (plant.MainImage != null)
            {
                
                
                    PlantImage plantImage = new PlantImage
                    {
                        ImagePath = await plant.MainImage.FileCreate(webHost.WebRootPath, @"assets\images\website-images"),
                        IsMain = false,
                        PlantId = existed.Id
                    };
                    existed.PlantImages.Add(plantImage);
                
            }


            context.Entry(existed).CurrentValues.SetValues(plant);
            await context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }


    }
}

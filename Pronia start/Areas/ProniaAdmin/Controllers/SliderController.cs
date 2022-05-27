using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_start.DAL;
using Pronia_start.Extensions;
using Pronia_start.Models;
using Pronia_start.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Pronia_start.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHost;

        public SliderController(AppDbContext context, IWebHostEnvironment webHost)
        {
            this.context = context;
            this.webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await context.Sliders.ToListAsync();

            return View(sliders);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            if (slider.Photo != null)
            {
                //    if (!slider.Photo.ContentType.Contains("image"))
                //    {
                //        ModelState.AddModelError("Photo", "please enter photo");
                //        return View();

                //    }
                //    if (slider.Photo.Length>1024*1024)
                //    {
                //        return View();
                //        ModelState.AddModelError("Photo", "Please upload an image up to 1 mb");

                //    }
                if (!slider.Photo.IsOkay(1))
                {
                    ModelState.AddModelError("Photo", "Please choose supported file");
                    return View();
                }
                string fileName = slider.Photo.FileName;
                string path = Path.Combine(webHost.WebRootPath, "images", "website-images");
                slider.Image = await slider.Photo.FileCreate(webHost.WebRootPath, @"assets\images\website-images");
                await context.Sliders.AddAsync(slider);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("Photo", "Please choose file");
                return View();
            }
        }



    }


}



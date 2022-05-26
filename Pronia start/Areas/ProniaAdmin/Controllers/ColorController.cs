using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_start.DAL;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Pronia_start.Models;
using Color = Pronia_start.Models.Color;

namespace Pronia_start.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class ColorController : Controller
    {
        
        private readonly AppDbContext context;

        
        public ColorController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
           List<Pronia_start.Models.Color>colors=await context.Colors.ToListAsync();
            return View(colors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Color color)
        {
            if (!ModelState.IsValid) return View();
            await context.Colors.AddAsync(color);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
           Color color = await context.Colors.FirstOrDefaultAsync(c => c.Id == id);
            if (color == null) return NotFound();
            return View(color);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Color color = await context.Colors.FirstOrDefaultAsync(c => c.Id == id);
            if (color == null) return NotFound();
            return View(color);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Color color)
        {

            Color existedColor = await context.Colors.FirstOrDefaultAsync(c=> c.Id == id);
            if (existedColor == null) return NotFound();
            if (id != color.Id) return BadRequest();

            existedColor.Name = color.Name;


            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }




        public async Task<IActionResult> Delete(int id)
        {
            Color color = await context.Colors.FirstOrDefaultAsync(c => c.Id == id);
            if (color == null) return NotFound();
            return View(color);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSize(int id)
        {
            Color color = await context.Colors.FirstOrDefaultAsync(c => c.Id == id);
            if (color == null) return NotFound();

            context.Colors.Remove(color);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

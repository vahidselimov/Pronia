using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_start.DAL;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Pronia_start.Models;
using Size = Pronia_start.Models.Size;

namespace Pronia_start.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class SizeController : Controller
    {
        private readonly AppDbContext context;

        public SizeController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Pronia_start.Models.Size> sizes = await context.Sizes.ToListAsync();
            return View(sizes);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Size size)
        {
            if (!ModelState.IsValid) return View();
            await context.Sizes.AddAsync(size);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Detail(int id)
        {
            Size size = await context.Sizes.FirstOrDefaultAsync(s => s.Id == id);
            if (size == null) return NotFound();
            return View(size);
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            Size size = await context.Sizes.FirstOrDefaultAsync(s => s.Id == id);
            if (size == null) return NotFound();
            return View(size);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Size size)
        {

            Size existedSize = await context.Sizes.FirstOrDefaultAsync(s => s.Id == id);
            if (existedSize == null) return NotFound();
            if (id != size.Id) return BadRequest();

            existedSize.Name = size.Name;

            //_context.Sizes.Update(size);

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }




        public async Task<IActionResult> Delete(int id)
        {
            Size size = await context.Sizes.FirstOrDefaultAsync(s => s.Id == id);
            if (size == null) return NotFound();
            return View(size);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSize(int id)
        {
            Size size = await context.Sizes.FirstOrDefaultAsync(s => s.Id == id);
            if (size == null) return NotFound();

            context.Sizes.Remove(size);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

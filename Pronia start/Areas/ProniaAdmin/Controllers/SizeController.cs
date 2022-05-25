using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_start.DAL;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace Pronia_start.Areas.ProniaAdmin.Controllers
{
    public class SizeController : Controller
    {
        private readonly AppDbContext context;

        public SizeController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Size> sizes = await context.Sizes.ToListAsync();
            return View(sizes);
        }
        public IActionResult Create()
        {
            return Json("Create");
        }
        public IActionResult Detail(int id)
        {
            return Json(id);
        }
        public IActionResult Edit(int id)
        {
            return Json(id);
        }

        public IActionResult Delete(int id)
        {
            return Json(id);
        }
    }
}

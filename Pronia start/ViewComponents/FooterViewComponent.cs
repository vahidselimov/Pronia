using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_start.DAL;
using Pronia_start.Models;
using System.Threading.Tasks;

namespace Pronia_start.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly AppDbContext context;

        public FooterViewComponent(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InVokeAsync()
        {
            Setting setting = await context.Settings.FirstOrDefaultAsync();
            return View(setting);

                
        }
            
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_start.DAL;
using Pronia_start.Models;
using Pronia_start.ViewModels;
using System.Collections.Generic;
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
           Setting Settings = await context.Settings.FirstOrDefaultAsync();
            List<SocialMedia> SocialMedias = await context.SocialMedias.ToListAsync();
            HomeVM homeVM = new HomeVM
            {
                Settings = Settings,
                SocialMedias = SocialMedias

            };
            return View(homeVM);
            
                
        }
            
    }
}

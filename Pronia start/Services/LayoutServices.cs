using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pronia_start.DAL;
using Pronia_start.Models;
using Pronia_start.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pronia_start.Services
{
    public class LayoutServices
    {
        private readonly AppDbContext context;
        private readonly IHttpContextAccessor httpContext;

        public LayoutServices(AppDbContext Context, IHttpContextAccessor httpContext)
        {
            context = Context;
            this.httpContext = httpContext;
        }
        public async Task<Setting> GetDatas()
        {
            return await context.Settings.FirstOrDefaultAsync();

        }
        public List<BasketCookItemVM> GetBasket()
        {
            string basketStr = httpContext.HttpContext.Request.Cookies["Basket"];
            if (!string.IsNullOrEmpty(basketStr))
            {
                //BasketVM basketData = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                List<BasketCookItemVM> basketData = JsonConvert.DeserializeObject<List<BasketCookItemVM>>(basketStr);
                return basketData;

            }
            else
            {
                return null;
            }
        }

    }

}


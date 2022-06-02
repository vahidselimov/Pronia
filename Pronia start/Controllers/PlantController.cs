using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pronia_start.DAL;
using Pronia_start.Models;
using Pronia_start.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Pronia_start.Controllers
{
    public class PlantController : Controller
    {
        private readonly AppDbContext context;

        public PlantController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> AddBasket(int id)
        {

            Plant plant = await context.Plants.FirstOrDefaultAsync(p => p.Id == id);
            if (plant == null) return NotFound();
            string basketStr = HttpContext.Request.Cookies["Basket"];
            BasketVM basket;
            string itemsStr;
            if (string.IsNullOrEmpty(basketStr))
            {
                basket = new BasketVM();
                BasketItemVM item = new BasketItemVM
                {

                    Plant = plant,
                    Count = 1
                };
                basket.baksetItems.Add(item);
                basket.TotalPrice = item.Plant.Price;
                basket.Count = 1;
                itemsStr = JsonConvert.SerializeObject(basket);

            }
            else
            {
                basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);

                BasketItemVM existedItem = basket.baksetItems.FirstOrDefault(i => i.Plant.Id == id);
                if (existedItem == null)
                {
                    BasketItemVM item = new BasketItemVM
                    {
                        Plant = plant,
                        Count = 1
                    };
                    basket.baksetItems.Add(item);
                }
                else
                {
                    existedItem.Count++;
                }

                decimal total = default;

                foreach (BasketItemVM item in basket.baksetItems)
                {
                    total += item.Plant.Price * item.Count;
                }
                basket.TotalPrice = total;
                basket.Count = basket.baksetItems.Count;
                itemsStr = JsonConvert.SerializeObject(basket);

            }

            HttpContext.Response.Cookies.Append("Basket", itemsStr);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ShowBasket()
        {
            return Content(HttpContext.Request.Cookies["Basket"]);
        }
    }
}


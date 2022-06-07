using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pronia_start.DAL;
using Pronia_start.Models;
using Pronia_start.ViewModels;
using System.Collections.Generic;
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
            //BasketVM basket;
            //string itemsStr;
            List<BasketCookItemVM> baskets;
            if (string.IsNullOrEmpty(basketStr))
            {
                baskets = new List<BasketCookItemVM>();
                BasketCookItemVM basketCook = new BasketCookItemVM
                {
                    Id = plant.Id,
                    Count=1

                };
                //BaksetItemVM item=new BaksetItemVM
                //{

                //    Plant = plant,
                //    Count = 1
                //};
                baskets.Add(basketCook);
                //basket.BaksetItems.Add(item);
                //basket.TotalPrice =item.Plant.Id;
                //basket.Count = 1;
                basketStr = JsonConvert.SerializeObject(baskets);

            }
            else
            {
                //basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                baskets = JsonConvert.DeserializeObject<List<BasketCookItemVM>>(basketStr);

                //BaksetItemVM existedItem = basket.BaksetItems.FirstOrDefault(i => i.Plant.Id == id);
                BasketCookItemVM basketCook = baskets.FirstOrDefault(c => c.Id == plant.Id);
                if (basketCook == null)
                {
                    BasketCookItemVM cookItemVM = new BasketCookItemVM
                    {
                        Id = plant.Id,
                        Count = 1
                    };
                    //basket.BaksetItems.Add(item);
                    baskets.Add(cookItemVM);
                  
                }
                else
                {
                    basketCook.Count++;
                }

                decimal total = default;

                //foreach (BasketCookItemVM item in baskets)
                //{
                //    //total += item.Plant.Price * item.Count;
                //}
                //basket.TotalPrice = total;
                //basket.Count = basket.BaksetItems.Count;
                basketStr = JsonConvert.SerializeObject(baskets);

            }

            HttpContext.Response.Cookies.Append("Basket", basketStr);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ShowBasket()
        {
            return Content(HttpContext.Request.Cookies["Basket"]);
        }
    }
}


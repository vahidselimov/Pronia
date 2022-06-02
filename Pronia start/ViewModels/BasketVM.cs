using Pronia_start.Controllers;
using Pronia_start.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pronia_start.ViewModels
{
    public class BasketVM
    {
    public List<BaksetItemVM> BaksetItems { get; set; }


        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalPrice { get; set; }
        public int Count { get; set; }

        public BasketVM()
        {
            BaksetItems = new List<BaksetItemVM>();
        }
    }
}

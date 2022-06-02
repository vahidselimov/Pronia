using Pronia_start.Controllers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pronia_start.ViewModels
{
    public class BasketVM
    {
    public List<BaksetItemVM> baksetItems { get; set; }


        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalPrice { get; set; }
        public int Count { get; set; }

       
    }
}

using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pronia_start.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlantCategory> PlantCategories { get; set; }
    }
}

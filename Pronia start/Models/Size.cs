using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Pronia_start.Models
{
    public class Size
    {

        public int Id { get; set; }
        [StringLength(maximumLength: 10)]
        public string Name { get; set; }
        
        public List<Plant> Plants { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Pronia_start.Models
{
    public class Size
    {

        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(maximumLength: 10)]
        public List<Plant> Plants { get; set; }
    }
}

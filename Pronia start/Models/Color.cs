using System.Collections.Generic;

namespace Pronia_start.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Color color;
        public Size size;
        public List<Plant> plants;
    }
}

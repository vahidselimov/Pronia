using Pronia_start.Models;
using System.Collections.Generic;

namespace Pronia_start.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Plant> Plants { get; set; }
        public Setting Settings { get; set; }
        public List<SocialMedia>SocialMedias{ get; set; }

    }
}

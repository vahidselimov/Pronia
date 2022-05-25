﻿namespace Pronia_start.Models
{
    public class PlantImage
    {

        public int Id { get; set; }
        public string ImagePath { get; set; }
        public bool? IsMain { get; set; }
        public int PlantId { get; set; }
        public Plant Plant { get; set; }

    }
}

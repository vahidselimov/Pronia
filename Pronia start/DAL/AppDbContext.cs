﻿using Microsoft.EntityFrameworkCore;
using Pronia_start.Models;

namespace Pronia_start.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantImage> PlantImages { get; set; }
        public DbSet<Size> Sizes { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pronia_start.Models;

namespace Pronia_start.DAL
{
    public class  AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AnotherSetting>()
                .HasIndex(u => u.Key)
                .IsUnique();
            base.OnModelCreating(builder);
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantImage> PlantImages { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PlantCategory> PlantCategories { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<AnotherSetting> AnotherSettings { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
    
    }
}

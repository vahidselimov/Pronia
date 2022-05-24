using Microsoft.EntityFrameworkCore;
using Pronia_start.Models;

namespace Pronia_start.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Pronia_start.DAL;
using Pronia_start.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Pronia_start.Services
{
    public class LayoutServices
    {
        private readonly AppDbContext context;

        public LayoutServices(AppDbContext Context)
        {
            context = Context;
        }
        public async Task<Setting> GetDatas()
        {
            return await context.Settings.FirstOrDefaultAsync();

        }
    }
}

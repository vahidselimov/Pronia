using Microsoft.AspNetCore.Identity;

namespace Pronia_start.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public string LastName { get; set; }
    }
}

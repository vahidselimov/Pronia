using System.ComponentModel.DataAnnotations;

namespace Pronia_start.ViewModels
{
    public class LoginVM
    {

        [Required, StringLength(maximumLength: 15)]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}

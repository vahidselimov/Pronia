using System;
using System.ComponentModel.DataAnnotations;

namespace Pronia_start.ViewModels
{
    public class RegisterVM
    {
        [Required,StringLength(maximumLength:15)]
        public string FirstName { get; set; }
        [Required,StringLength(maximumLength:(30))]
        public string LastName { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required,DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}

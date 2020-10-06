using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamRedWebApi.Models.UserModel
{
#pragma warning disable CS1591
    public class CreateUserDto
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [MinLength(3, ErrorMessage = "Password length must be longer then 2")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
#pragma warning restore CS1591
}

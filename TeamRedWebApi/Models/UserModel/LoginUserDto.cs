using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamRedWebApi.Models.UserModel
{
    public class LoginUserDto
    {
        [MinLength(3, ErrorMessage = "Username length must be longer then 2")]
        [Required(ErrorMessage = "Username is required")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [MinLength(3, ErrorMessage = "Password length must be longer then 2")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

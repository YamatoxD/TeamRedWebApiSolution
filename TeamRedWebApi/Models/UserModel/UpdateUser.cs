using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamRedWebApi.Models.UserModel
{
#pragma warning disable CS1591
    public class UpdateUser
    {

        [Required]
        public int UserId { get; set; }

        [Required]
        [Range(1,5)]
        public int Value { get; set; }
    }
#pragma warning restore CS1591
}

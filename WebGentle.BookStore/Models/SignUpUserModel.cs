using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebGentle.BookStore.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage ="Enter your email")]
        [Display(Name ="Email")]
        [EmailAddress(ErrorMessage ="please enter valid emai")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your Password")]
        [Display(Name = "Password")]
        [Compare("ConfirmPassword", ErrorMessage ="Password doesn't match")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter your Confirm Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}

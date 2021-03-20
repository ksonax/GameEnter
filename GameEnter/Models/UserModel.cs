using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameEnter.Models
{
    public class UserModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "You need to provide your user name.")]
        public string UserName { get; set; }
        
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "You need to provide your email adress.")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name = "Confirm Email")]
        [Compare("EmailAddress", ErrorMessage ="The Email and Confirm Email must match")]
        public string ConfirEmail { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage ="Your password must be at least 8 charaters long.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalizationLocaliztion011.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "UserNameRequired")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "PasswordRequired")]
        [DataType(DataType.Password)]
        [StringLength(8,ErrorMessage ="PasswordLengthError",MinimumLength =6)]
        [Display(Name= "Password")]
        public string Password { get; set; }
    }
}

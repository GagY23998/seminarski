using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Polje ne smije biti prazno")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Polje ne smije biti prazno")]
        public string Password { get; set; }
    }
}

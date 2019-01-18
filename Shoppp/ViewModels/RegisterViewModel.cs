using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z]{5,}\d+")]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z]{5,}")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z]{5,}")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@".+@hotmail\.com")]
        public string Email { get; set; }

    }
}

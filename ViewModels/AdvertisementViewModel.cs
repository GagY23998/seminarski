using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace OnlineShopping.ViewModels
{
    public class AdvertisementViewModel
    {
        public DateTime RegistrationDate { get; set; }
        [Required(ErrorMessage ="Incorrect Date")]
        [DataType(DataType.DateTime,ErrorMessage ="Enter valid date")]
        public DateTime ExpirationDate { get; set; }
        public byte[] Image { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string UserName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}

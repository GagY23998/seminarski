using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace OnlineShopping.ViewModels
{
    public class AdvertisementTypeViewModel
    {
        [Required(ErrorMessage ="Polje ne smije biti prazno")]
        public string AdvertisementType { get; set; }
    }
}

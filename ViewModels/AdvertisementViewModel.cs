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
        [Required(ErrorMessage ="Datum ne smije biti prazan")]
        [DataType(DataType.DateTime,ErrorMessage ="Unesite ispravan datum")]
        public DateTime ExpirationDate { get; set; }
        public byte[] Image { get; set; }
        [Required(ErrorMessage = "Polje ne smije biti prazno")]
        public string UserName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}

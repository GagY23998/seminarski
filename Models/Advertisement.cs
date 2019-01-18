using OnlineShopping.HelperUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{
    public class Advertisement
    {
        public int AdvertisementId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public int AdvertisementTypeID { get; set; }
        public AdvertisementType AdvertisementType { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}

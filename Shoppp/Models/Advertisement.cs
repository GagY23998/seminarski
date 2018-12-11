using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppp.Models
{
    public class Advertisement
    {
        [Key]
        public int AdvertisementId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public byte[] Image { get; set; }
        public string Opis { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppp.Models
{
    public class AdvertisementType
    {
        [Key]
        public int AdTypeId { get; set; }
        public string TypeName { get; set; }
    }
}

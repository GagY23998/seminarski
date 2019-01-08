using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CartName { get; set; }
        public List<Artikl> Artikli { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{
    public class Favorites
    {
        [Key]
        public int FavoritesId { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Artikl> Artikli { get; set; }

    }
}

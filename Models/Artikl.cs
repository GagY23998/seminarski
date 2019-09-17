using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{
    public class Artikl
    {
       
        [Key]
        public int ArtiklID { get; set; }
        [Required]
        [MinLength(4)]
        public string ImeArtikla { get; set; }
        [Required]
        public decimal CijenaArtikla { get; set; }
        [Required]
        public int NaStanju { get; set; }
        public DateTime VrijemePostavlanja { get; set; }
        public byte[] SlikaArtikla { get; set; }
        Kategorija Kategorija { get; set; }
        public int KategorijaID { get; set; }
        }
}

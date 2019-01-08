using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShopping.ViewModels
{
    public class ArtiklOneViewModel
    {
        [Required(ErrorMessage ="Polje ne smije biti prazno")]
        [StringLength(100)]
        public string ImeArtikla { get; set; }
        [Required(ErrorMessage ="Polje ne smije biti prazno")]
        [RegularExpression(@"^\d+\,\d{0,2}$")]
        [Range(0,5000.00)]
        public decimal CijenaArtikla { get; set; }
        [Range(1,100,ErrorMessage ="Vrijednost mora biti između 1 i 100")]
        public int NaStanju { get; set; }
        public byte[] SlikaArtikla { get; set; }
        [Required(ErrorMessage ="Polje ne smije biti prazno")]
        [StringLength(100,ErrorMessage ="Prekoračili ste dozvoljeni broj slova")]
        [DataType(DataType.Text,ErrorMessage ="Ime kategorije ne smije sadržavati bilo kakve vrijedonst osim teksta")]
        public string ImeKategorije { get; set; }
    }
}

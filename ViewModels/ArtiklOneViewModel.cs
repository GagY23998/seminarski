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
        [Required(ErrorMessage ="Field can't be empty")]
        [StringLength(100)]
        public string ImeArtikla { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        //[RegularExpression(@"^\d+\,\d{0,2}$")]
        //[Range(0,5000.00)]
        public decimal CijenaArtikla { get; set; }
        [Range(1,100,ErrorMessage ="Value must be beteween 1 i 100")]
        public int NaStanju { get; set; }
        public byte[] SlikaArtikla { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(100,ErrorMessage ="Max string length is 100")]
        [DataType(DataType.Text,ErrorMessage ="Field must contain only text")]
        public string ImeKategorije { get; set; }
    }
}

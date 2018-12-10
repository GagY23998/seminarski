using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShopping.ViewModels
{
    public class ArtiklOneViewModel
    {
        public string ImeArtikla { get; set; }
        public float CijenaArtikla { get; set; }
        public int Kolicina { get; set; }
        public byte[] SlikaArtikla { get; set; }
        public string ImeKategorije { get; set; }
    }
}

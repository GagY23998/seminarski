using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class Artikl
    {
        public int ArtiklID { get; set; }
        public string ImeArtikla { get; set; }
        public float CijenaArtikla { get; set; }
        public string Stanje { get; set; }
        public DateTime VrijemePostavlanja { get; set; }
        public byte[] SlikaArtikla { get; set; }
        Kategorija Kategorija { get; set; }
        public int KategorijaID { get; set; }

    }
}

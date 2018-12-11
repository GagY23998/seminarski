using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppp.Models
{
    public class Kategorija
    {
        public int KategorijaID { get; set; }
        public string ImeKategorije { get; set; }
        public CategoryCharachteristic OpisKategorije { get; set; }
        public int OpisKategorijeID { get; set; }
    }
}

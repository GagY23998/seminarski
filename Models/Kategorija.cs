﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{
    public class Kategorija
    {
        public int KategorijaID { get; set; }
        public string ImeKategorije { get; set; }
        public List<CategoryCharachteristic> OpisKategorije { get; set; }
    }
}

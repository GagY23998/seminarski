using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopping.Models;

namespace OnlineShopping.ViewModels
{
    public class KategorijaViewModel
    {
        [Required]
        public string ImeKategorije { get; set; }
        public List<CategoryCharachteristic> charachteristics { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{
    public class CategoryCharachteristic
    {
        public int CategoryCharachteristicId { get; set; }
        public string CharName { get; set; }
        public int Priority { get; set; }
        public int KategorijaID { get; set; }
    }
}

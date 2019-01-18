using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopping.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.ViewModels
{
    public class ArtiklViewModel :IEnumerable
    {
       public IEnumerable<Artikl> Articles { get; set; }
        public string naziv { get; set; }
        public int KategorijaID { get; set; }
        public List<SelectListItem> Kategorije { get; set; }
        public List<ArtiklOneViewModel> ArticlesExpire { get; set; }
        public IEnumerator GetEnumerator()
        {
            return Articles.GetEnumerator();
        }
    }
}

using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace OnlineShopping.ViewModels
{
    public class ArticlePurchaseHistoryViewModel
    {
        public IdentityUser User { get; set; }
        public Artikl Artikl { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Amount { get; set; }
        public double TotalPrice => Artikl.CijenaArtikla * Amount;
    }
   
}

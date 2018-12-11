using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Shoppp.HelperUser;

namespace Shoppp.Models
{
    public class ArticleBuyingHistory
    {
        public int ArticleBuyingHistoryID { get; set; }
        public string UserID { get; set; }
        public AppUser User { get; set; }
        public int ArtiklID { get; set; }
        public Artikl Artikl { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Amount { get; set; }
        public int Quantity { get; set; }
    }
}

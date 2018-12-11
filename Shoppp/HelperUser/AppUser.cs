using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Shoppp.Models;

namespace Shoppp.HelperUser
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Cart Korpa { get; set; }
        public Favorites Omiljeni { get; set; }
        public int Rate { get; set; }
    }
}

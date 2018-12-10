using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.ViewComponents
{
    public class CRUDViewComponent :ViewComponent
    {

        public IViewComponentResult Invoke() => View("CRUD");

    }
}

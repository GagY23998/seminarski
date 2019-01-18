
using OnlineShopping.Models;
using OnlineShopping.Services;
using OnlineShopping.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OnlineShopping.HelperUser;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShopping.Controllers
{
    public class HomeController : Controller
    {
        public IArtikliService Service { get; }
        public HomeController(IArtikliService service) { Service = service; }
        public async Task<IActionResult> Index(string naziv, int? KategorijaID)
        {

            List<SelectListItem> kategorije = new List<SelectListItem>() { new SelectListItem() {  Value=string.Empty,Text="Odaberi Kategoriju"}  };
            var k = Service.GetCategories();
            foreach (var item in k)
            {
                kategorije.Add(new SelectListItem() { Value =item.KategorijaID.ToString(), Text =item.ImeKategorije });
            }
            var model = new ArtiklViewModel { Articles = Service.GetArticlesByName(naziv,KategorijaID) };
            model.Kategorije =kategorije;
            return View(model);
        }
        
    }
  
}
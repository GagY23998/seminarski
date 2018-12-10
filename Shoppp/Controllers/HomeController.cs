
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

namespace OnlineShopping.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public IArtikliService Service { get; }
        public HomeController(IArtikliService service,SignInManager<AppUser> signInManager,UserManager<AppUser> userManager)
        {
            Service = service;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [AllowAnonymous]    
        public async Task<IActionResult> Index()
        {
            if (signInManager.IsSignedIn(User))
            {
                var user = await userManager.GetUserAsync(User);
                HttpContext.Session.SetUser(user);
            }
            var model = new ArtiklViewModel { Articles = Service.GetArticles() };
          
            return View(model);
        }
        [HttpGet]
        public IActionResult DodajArtikl()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DodajArtikl(ArtiklOneViewModel artikl, IFormFile SlikaArtikla)
        {
            if (SlikaArtikla != null)
            {
                using (var memStream = new MemoryStream())
                {
                    await SlikaArtikla.CopyToAsync(memStream);
                    artikl.SlikaArtikla = memStream.ToArray();
                }
            }
            if (ModelState.IsValid)
            {
                var kategorija = Service.GetKategorija(artikl.ImeKategorije);
                var model = new Artikl
                {
                    ImeArtikla = artikl.ImeArtikla,
                    Kolicina = artikl.Kolicina,
                    CijenaArtikla = artikl.CijenaArtikla,
                    KategorijaID = kategorija.KategorijaID,
                    SlikaArtikla = artikl.SlikaArtikla,
                    VrijemePostavlanja = DateTime.Now
                };
                Service.CreateArticle(model);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult DodajKategoriju()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DodajKategoriju(KategorijaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Kategorija kategorija = new Kategorija { ImeKategorije = viewModel.ImeKategorije };
                Service.AddCategory(kategorija);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult IzbrisiArtikl()
        {
            var model = Service.GetArticles();
            return View(model);
        }
        [HttpPost]
        public IActionResult IzbrisiArtikl(int ArtiklID)
        {
            if (ModelState.IsValid)
            {
                Service.DeleteArticle(ArtiklID);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult IzmijeniArtikl()
        {
            var model = Service.GetArticles();
            return View(model);
        }
        [HttpPost]
        public IActionResult IzmijeniArtikl(ArtiklOneViewModel artikl, IFormFile SlikaArtikla, int ArtiklID)
        {
            if (ModelState.IsValid)
            {
                var model = new Artikl
                {
                    ImeArtikla = artikl.ImeArtikla,
                    CijenaArtikla = artikl.CijenaArtikla,
                    Kolicina= artikl.Kolicina,
                    VrijemePostavlanja = DateTime.Now,
                    KategorijaID = Service.GetKategorija(artikl.ImeKategorije).KategorijaID

                };
                using (var mm = new MemoryStream())
                {
                    SlikaArtikla.CopyTo(mm);
                    model.SlikaArtikla = mm.ToArray();
                }
                Service.ChangeArticle(ArtiklID, model);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult GetArticles(string Pretraga)
        {
            var model = Service.GetArticlesByCategory(Pretraga);
            return PartialView(model);
        }
        [HttpGet]
        public IActionResult SeeArticleHistory() => View();
        [HttpPost]
        public IActionResult SeeArticleHistory(string Pretraga)
        {
            var artiklID = Service.GetArticleIDbyName(Pretraga);
            if (artiklID == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var model = Service.GetSoldArticles(artiklID);
            return PartialView("PartialHistory",model);
        }
        [HttpGet]
        public IActionResult AzurirajKolicinu()
        {
            var model = Service.GetArticles().ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult AzurirajKolicinu(List<Artikl> artikli)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in artikli)
                { 
                    Service.ChangeArticle(item.ArtiklID, item);
                }
                return RedirectToAction(nameof(Index));
            }
            return Content("Shit happend");
        }

    }
}

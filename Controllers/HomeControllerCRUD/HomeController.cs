
using CRUD.Models;
using CRUD.Services;
using CRUD.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        public IArtikliService Service { get; }
        public HomeController(IArtikliService service)
        {
            Service = service;
        }
        public IActionResult Index()
        {
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
                    Stanje = artikl.Stanje,
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
        public IActionResult GetImage(int artiklID)
        {
            var model = Service.GetArticle(artiklID).SlikaArtikla;
            FileResult fileResult = File(model, "image/png");
            return fileResult;
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
                    Stanje = artikl.Stanje,
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
    }
}

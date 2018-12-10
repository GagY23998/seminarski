using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using OnlineShopping.Data;
using OnlineShopping.Models;
using OnlineShopping.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopping.Services
{
    public class ArtikliService : IArtikliService
    {
        public ArtikliService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationDbContext _context { get; private set; }

        public Kategorija AddCategory(Kategorija kategorija)
        {
            _context.Add(kategorija);
            _context.SaveChanges();
            return kategorija;
        }

        public Artikl ChangeArticle(int articleID,Artikl noviArtikl)
        {
            var artikl = _context.Artikli.Find(articleID);
            artikl.ImeArtikla = noviArtikl.ImeArtikla;
            artikl.SlikaArtikla = noviArtikl.SlikaArtikla;
            artikl.VrijemePostavlanja = noviArtikl.VrijemePostavlanja;
            artikl.CijenaArtikla = noviArtikl.CijenaArtikla;
            artikl.Kolicina = noviArtikl.Kolicina;
            _context.Update(artikl).State = EntityState.Modified;
            _context.SaveChanges();
            return artikl;
        }

        public Artikl CreateArticle(Artikl noviArtikl)
        {
            _context.Add(noviArtikl);
            _context.SaveChanges();
            return noviArtikl;
        }

        public Artikl DeleteArticle(int articleID)
        {
            var artikl = _context.Artikli.FirstOrDefault(artikal => artikal.ArtiklID == articleID);
            _context.Artikli.Remove(artikl);
            _context.SaveChanges();
            return artikl;
        }

        public Kategorija DeleteCategory(int kategorijaID)
        {
            var kategorija = _context.Kategorije.FirstOrDefault(kat => kat.KategorijaID == kategorijaID);
            _context.Remove(kategorija);
            _context.SaveChanges();
            return kategorija;
        }

        public Artikl GetArticle(int articleID)
        {
            var model= _context.Artikli.FirstOrDefault(ar => ar.ArtiklID == articleID);
            return model;
        }

        public int GetArticleIDbyName(string name)
        {
            return _context.Artikli.FirstOrDefault(a => a.ImeArtikla == name).ArtiklID;
        }

        public IEnumerable<Artikl> GetArticles()
        {
            return _context.Artikli.OrderBy(art => art.ImeArtikla);
        }

        public IEnumerable<Artikl> GetArticlesByCategory(string pretraga)
        {
            var kategorija = _context.Kategorije.FirstOrDefault(k => k.ImeKategorije == pretraga);
            var model = _context.Artikli.Where(a => a.KategorijaID == kategorija.KategorijaID).ToList();
            return model;
        }

        public Kategorija GetKategorija(string imeKategorije)
        {
            var model = _context.Kategorije.FirstOrDefault(k => k.ImeKategorije == imeKategorije);
            return model;
        }

        public IEnumerable<ArticlePurchaseHistoryViewModel> GetSoldArticles(int ArticleID)
        {
            var artikl = _context.Artikli.FirstOrDefault(a => a.ArtiklID == ArticleID);
            var articleUsers = _context.BuyingHistory.Where(arh => arh.ArtiklID == ArticleID);
            var model = articleUsers.Select(arh =>new ArticlePurchaseHistoryViewModel
            {
                Amount = arh.Amount,
                PurchaseDate=arh.PurchaseDate,
                User = _context.Users.FirstOrDefault(u=>u.Id == arh.UserID),
                Artikl = artikl
            });
            return model;
        }
    }
}

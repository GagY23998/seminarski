using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using OnlineShopping.Data;
using OnlineShopping.Models;
using OnlineShopping.ViewModels;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.HelperUser;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Globalization;

namespace OnlineShopping.Services
{
    public class ArtikliService : IArtikliService
    {
        public ArtikliService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationDbContext _context { get; private set; }

        
        public void MarkAsRead(int id)
        {
            var message = _context.MessageBoxes.FirstOrDefault(m => m.MessageBoxID == id);
            message.IsRead = !message.IsRead ? true : true;
            _context.SaveChanges();
        }
        public IEnumerable<Kategorija> GetCategories()
        {
            return _context.Categories.OrderBy(k => k.ImeKategorije);

        }
        public Kategorija AddCategory(Kategorija kategorija)
        {
            _context.Add(kategorija);
            _context.SaveChanges();
            return kategorija;
        }

        public Artikl ChangeArticle(int articleID,Artikl noviArtikl)
        {
            var artikl = _context.Articles.Find(articleID);
            artikl.ImeArtikla = noviArtikl.ImeArtikla;
            artikl.SlikaArtikla = noviArtikl.SlikaArtikla;
            artikl.VrijemePostavlanja = noviArtikl.VrijemePostavlanja;
            artikl.CijenaArtikla = noviArtikl.CijenaArtikla;
            artikl.NaStanju = noviArtikl.NaStanju;
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
            var artikl = _context.Articles.FirstOrDefault(artikal => artikal.ArtiklID == articleID);
            _context.Articles.Remove(artikl);
            _context.SaveChanges();
            return artikl;
        }

        public Kategorija DeleteCategory(int kategorijaID)
        {
            var kategorija = _context.Categories.FirstOrDefault(kat => kat.KategorijaID == kategorijaID);
            var tags = _context.CategoryCharachteristics.Where(_ => _.KategorijaID == kategorija.KategorijaID);
            _context.CategoryCharachteristics.RemoveRange(tags);
            _context.Remove(kategorija);
            _context.SaveChanges();
            return kategorija;
        }

        public Artikl GetArticle(int articleID)
        {
            if(articleID!=0) { 
            var model= _context.Articles.FirstOrDefault(ar => ar.ArtiklID == articleID);
            return model;
            }
            return null;
        }

        public int GetArticleIDbyName(string name)
        {
            return _context.Articles.FirstOrDefault(a => a.ImeArtikla == name).ArtiklID;
        }

        public IEnumerable<Artikl> GetArticles( )
        {
            return _context.Articles.OrderBy(art => art.ImeArtikla).ToList();
        }
        public IEnumerable<Artikl> GetArticlesByName(string naziv,int?KategorijaID)
        {
            return _context.Articles.Where(x=>(x.ImeArtikla.Contains(naziv)|| naziv==null)&&(x.KategorijaID==KategorijaID || KategorijaID==null)).OrderBy(art => art.ImeArtikla);
        }
        public IEnumerable<Artikl> GetArticlesByCategory(string pretraga)
        {
            var kategorija = _context.Categories.FirstOrDefault(k => k.ImeKategorije == pretraga);
            if (kategorija == null) return null;
            var model = _context.Articles.Where(a => a.KategorijaID == kategorija.KategorijaID).ToList();
            return model;
        }

        public Kategorija GetCategory(string imeKategorije)
        {
            var model = _context.Categories.FirstOrDefault(k => k.ImeKategorije == imeKategorije);
            return model;
        }

        public IEnumerable<ArticlePurchaseHistoryViewModel> GetSoldArticles(int ArticleID)
        {
            var artikl = _context.Articles.FirstOrDefault(a => a.ArtiklID == ArticleID);
            var articleUsers = _context.BuyingHistory.Where(arh => arh.ArtiklID == ArticleID);
            var model = articleUsers.Select(arh =>new ArticlePurchaseHistoryViewModel
            {
                Amount = arh.Amount,
                PurchaseDate=arh.PurchaseDate,
                User = _context.Users.FirstOrDefault(u=>u.Id == arh.User.Id),
                Artikl = artikl
            });
            return model.ToList();
        }
        public List<ArtiklOneViewModel> ArticlesExpire()
        {
            var model = _context.Articles.Where(ar => ar.NaStanju < 5).Select(a => new ArtiklOneViewModel {
                ImeArtikla = a.ImeArtikla,
                NaStanju = a.NaStanju,
                ImeKategorije = _context.Categories.FirstOrDefault(k => k.KategorijaID == a.KategorijaID).ImeKategorije,
                CijenaArtikla = a.CijenaArtikla,
                SlikaArtikla = a.SlikaArtikla,
            });
            return model.ToList();
        }
        public AppUser GetUser(string email)
        {
            var model = _context.Users.FirstOrDefault(user => user.Email == email);
            return model;
        }

        public void AddMessage(AppUser sender, AppUser reciever,string subject, string message,IFormFile attachment)
        {
            MemoryStream memoryStream = null;
            if (attachment != null)
            {
            memoryStream = new MemoryStream();
            attachment.CopyTo(memoryStream);
            }
            var newMsg = new MessageBox
            {
                SenderID = sender.Id,
                ReciverID = reciever.Id,
                Subject = subject,
                Message = message,
                CreationDate = DateTime.Now,
                IsRead = false
            };
            newMsg.Attachment = memoryStream != null ? memoryStream.ToArray() : null;
            _context.MessageBoxes.Add(newMsg);
            _context.SaveChanges();
        }
        public int GetUnreadMessages(string userID)
        {
            var model = _context.MessageBoxes.Where(m => m.ReciverID == userID && m.IsRead == false).ToList().Count;
            return model;
        }
        public AppUser GetUserByID(string id)
        {
            var model = _context.Users.FirstOrDefault(u => u.Id == id);
            return model;
        }

        public List<MessageBox> GetMessages(string userID)
        {
            var reciever = _context.Users.FirstOrDefault(u=>u.Id == userID);
            var senders = _context.MessageBoxes.Where(m => m.ReciverID == userID);
            var users = new List<MessageBox>();
            foreach (var sender in senders)
            {
                var temp = _context.Users.FirstOrDefault(u => sender.SenderID == u.Id);
                users.Add(new MessageBox
                {
                   ReciverID = userID,
                   SenderID = temp.Id,
                   Subject = sender.Subject,
                   Message =sender.Message,
                   CreationDate = sender.CreationDate,
                   IsRead =sender.IsRead,
                   MessageBoxID = sender.MessageBoxID
                });
            }
            return users;
        }
        public bool GetMessageByName(string subject, string username,DateTime date)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == username);
            if (user != null)
            {
            var model = _context.MessageBoxes.FirstOrDefault(message =>
            message.Subject == subject && 
            message.SenderID == user.Id &&
            message.CreationDate == date);
            _context.Remove(model);
            _context.SaveChanges();
                return true;
            }
            return false;
        }
        public MessageBox GetMessageBoxID(string subject,string username,string date)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == username);
            var model = _context.MessageBoxes.FirstOrDefault(message =>
            message.Subject == subject &&
            message.SenderID == user.Id &&
            String.Compare(message.CreationDate.ToString(),date,StringComparison.CurrentCulture)==0);
            return model;
        }

        public MessageBox GetMessage(int id)
        {
            var model = _context.MessageBoxes.FirstOrDefault(m => m.MessageBoxID == id);
            return model;
        }
        public Kategorija GetCategoryByID(int id)
        {
            var model = _context.Categories.FirstOrDefault(k => k.KategorijaID == id);
            var characteristics = _context.CategoryCharachteristics.Where(ch => ch.KategorijaID == id).ToList();
            model.OpisKategorije = new List<CategoryCharachteristic>(characteristics);            
            return model;
        }
        public IEnumerable<AppUser> GetUsers()
        {
            var model = _context.Users.ToList();
            return model;
        }

        public Advertisement AddAdvertisement(AdvertisementViewModel viewModel,byte[]picture)
        {
            var newAd = new Advertisement
            {
                Description = viewModel.Description,
                ExpirationDate = viewModel.ExpirationDate,
                RegistrationDate = DateTime.Now,
                AdvertisementTypeID = _context.AdvertisementTypes.FirstOrDefault(adT => adT.TypeName == viewModel.TypeName).AdTypeId,
                Image = picture,
                AppUserId = _context.Users.FirstOrDefault(u=>u.UserName == viewModel.UserName).Id
            };
            _context.Add(newAd);
            _context.SaveChanges();
            return newAd;
        }
        public Advertisement DeleteAdvertisement(int id)
        {
            var model =_context.Advertisements.FirstOrDefault(ad => ad.AdvertisementId == id);
            _context.Advertisements.Remove(model);
            _context.SaveChanges();
            return model;
        }
        public Advertisement ChangeExpirationDate(int id, AdvertisementViewModel viewModel)
        {
            var model = _context.Advertisements.FirstOrDefault(ad => ad.AdvertisementId == id);
            model.ExpirationDate = viewModel.ExpirationDate;
            model.Description = viewModel.Description??model.Description;
            model.Image = viewModel.Image ?? model.Image;
            _context.Advertisements.Update(model);
            _context.SaveChanges();
            return model;
        }

        public AdvertisementType AddAdvertisementType(AdvertisementTypeViewModel viewModel)
        {
            var model = new AdvertisementType
            {
                TypeName = viewModel.AdvertisementType
            };
            _context.Add(model);
            _context.SaveChanges();
            return model;
        }

        public AdvertisementType DeleteAdvertisementType(int id)
        {
            var model = _context.AdvertisementTypes.FirstOrDefault(adType => adType.AdTypeId == id);
            _context.Remove(model);
            _context.SaveChanges();
            return model;
        }
        public List<AdvertisementViewModel> GetAdvertisements()
        {
            var model = _context.Advertisements.Select(ad => new AdvertisementViewModel {
                Description = ad.Description,
                TypeName = _context.AdvertisementTypes.FirstOrDefault(adT => ad.AdvertisementTypeID == adT.AdTypeId).TypeName,
                ExpirationDate = ad.ExpirationDate,
                RegistrationDate = ad.RegistrationDate,
                Image = ad.Image,
                UserName = _context.Users.FirstOrDefault(u=>u.Id == ad.AppUserId).UserName
            }).ToList();
            return model;
        }
        public Advertisement GetAdvertisementByNameUser(string typename, string username, string date)
        {
            var model = _context.Advertisements.FirstOrDefault(
                ad =>
                typename == _context.AdvertisementTypes.FirstOrDefault(adT => adT.AdTypeId == ad.AdvertisementTypeID).TypeName &&
                username == _context.Users.FirstOrDefault(u => u.Id == ad.AppUserId).UserName &&
                String.Compare(date,ad.RegistrationDate.ToString(),StringComparison.CurrentCulture) == 0);
            return model;
        }
        public Advertisement GetAdvertisement(int id)
        {
            var model = _context.Advertisements.FirstOrDefault(ad => ad.AdvertisementId == id);
            return model;
        }
        public AdvertisementType GetAdvertisementType(int id)
        {
            var model = _context.AdvertisementTypes.FirstOrDefault(adT => adT.AdTypeId == id);
            return model;
        }
        public AdvertisementType GetAdvertisementTypeByName(string name)
        {
            var model = _context.AdvertisementTypes.FirstOrDefault(adT => adT.TypeName == name);
            _context.AdvertisementTypes.Remove(model);
            return model;
        }
        public List<AdvertisementTypeViewModel> GetAdvertisementTypeModels()
        {
            var model = _context.AdvertisementTypes.OrderBy(adT => adT.TypeName).Select(adT=>new AdvertisementTypeViewModel { AdvertisementType = adT.TypeName}).ToList();
            return model;
        }

        public void ChangePicture(string UserID,byte[] pic)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == UserID);
            user.Picture = pic;
            _context.Update(user).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

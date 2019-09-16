
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

namespace OnlineShopping.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IArtikliService Service { get; }
        public AdminController(IArtikliService service,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager
            )

        {
            Service = service;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
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
        public IActionResult NotificationArticles() => View(Service.ArticlesExpire());
        [HttpGet]
        public IActionResult AddArticle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddArticle(ArtiklOneViewModel artikl, IFormFile SlikaArtikla)
        {
            if (SlikaArtikla != null)
            {
                using (var memStream = new MemoryStream())
                {
                    await SlikaArtikla.CopyToAsync(memStream);
                    artikl.SlikaArtikla = memStream.ToArray();
                }
            }


            if (artikl != null && ModelState.IsValid)
            {
                var kategorija = Service.GetCategory(artikl.ImeKategorije);
                var model = new Artikl
                {
                    ImeArtikla = artikl.ImeArtikla,
                    NaStanju = artikl.NaStanju,
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
        public IActionResult AddCategory() => View();
        [HttpPost]
        public IActionResult AddCategory(KategorijaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Kategorija kategorija = new Kategorija { ImeKategorije = viewModel.ImeKategorije, OpisKategorije = viewModel.charachteristics };
                Service.AddCategory(kategorija);
                return RedirectToAction(nameof(Index));
            }
            return View("AddCategory");
        }
        [HttpGet(Order = 1)]
        public IActionResult DeleteArticle()
        {
            var model = Service.GetArticles();
            return View(model.ToList());
        }
        [HttpGet("/Admin/DeleteArticle/{articleID}")]
        public IActionResult DeleteArticle(int articleID)
        {
            if (ModelState.IsValid)
            {
                Service.DeleteArticle(articleID);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult ChangeArticle(int id) {

            var model = Service.GetArticle(id);
            if (model ==null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult ChangeArticle(Artikl artikl, IFormFile slika, string ImeKategorije)
        {
            if (artikl == null ||ImeKategorije == null) return View(nameof(Index));
            var model = new Artikl
            {
                ImeArtikla = artikl.ImeArtikla,
                CijenaArtikla = artikl.CijenaArtikla,
                NaStanju = artikl.NaStanju,
                VrijemePostavlanja = DateTime.Now,
                KategorijaID = Service.GetCategory(ImeKategorije).KategorijaID,
                ArtiklID = artikl.ArtiklID
            };
            if (slika == null)
            {
                model.SlikaArtikla = Service.GetArticle(artikl.ArtiklID).SlikaArtikla;
            }
            else
            {
                var mm = new MemoryStream();
                slika.CopyTo(mm);
                model.SlikaArtikla = mm.ToArray();
            }
            Service.ChangeArticle(model.ArtiklID, model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult GetArticles(string Pretraga)
        {
            var model = Service.GetArticlesByCategory(Pretraga);
            if (model == null) return View(nameof(Index));
            return PartialView(model);
        }
        [HttpGet]
        public IActionResult SeeArticleHistory() => View();
        [HttpPost]
        public IActionResult SeeArticleHistory(string Pretraga)
        {
            var artiklID = Service.GetArticleIDbyName(Pretraga);
            if (artiklID == 0)
            {
                return Content("Article doesn't exist");
            }
            var model = Service.GetSoldArticles(artiklID);
            return PartialView("PartialHistory", model);
        }
        [HttpGet]
        public IActionResult UpdateQuantity()
        {
            var model = Service.GetArticles().ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateQuantity(List<Artikl> artikli)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in artikli)
                {
                    Service.ChangeArticle(item.ArtiklID, item);
                }
                return RedirectToAction(nameof(Index));
            }
            return Content("Error 404");
        }
        [HttpGet]
        public IActionResult GetArticleOfCategory(string pretraga)
        {
            var model = Service.GetArticlesByCategory(pretraga);
            return PartialView("_ArtiklCategory", model);
        }
        [HttpGet]
        public async Task<IActionResult> GetMessage()
        {
            var user = await userManager.GetUserAsync(User);
            var model = Service.GetMessages(user.Id);
            if (model.Count==0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult SendMessage() => View();
        [HttpPost]
        public async Task<IActionResult> SendMessage(string Email, string subject, string Message, IFormFile attachment)
        {
            if (ModelState.IsValid)
            {
                var sender = await userManager.GetUserAsync(User);
                if (Email == sender.Email) return Content("Can't send message to yourself");
                var reciever = Service.GetUser(Email);
                if (reciever == null)
                {
                    return Content("Invalid Email");
                }
                if (!attachment.ContentType.Contains("image"))
                {
                    return Content("Unsupported file format");
                }
                Service.AddMessage(sender, reciever, subject, Message.Trim(), attachment);
                return RedirectToAction(nameof(GetMessage));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Getuser(string name)
        {
            if (ModelState.IsValid)
            {
                return Json(Service.GetUser(name));
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult ReadMessage(int id)
        {
            if (ModelState.IsValid)
            {
                var msg = Service.GetMessage(id);
                Service.MarkAsRead(msg.MessageBoxID);
                var user = Service.GetUserByID(msg.SenderID);
                var model = new MessageViewModel
                {
                    Subject = msg.Subject,
                    Message = msg.Message,
                    IsRead = msg.IsRead,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CreationDate = msg.CreationDate,
                    UserName = user.UserName,
                    Attachment = msg.Attachment
                };
                return View(model);
            }
            return RedirectToAction(nameof(GetMessage));
        }
        [HttpGet]
        public IActionResult DeleteMessage() => View();
        [HttpPost]
        public IActionResult DeleteMessage(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = Service.GetMessageByName(model.Subject, model.UserName, model.CreationDate);
                return RedirectToAction(nameof(GetMessage));
            }
            return Content("Somethin went wrong");
        }
        [HttpGet]
        public IActionResult DeleteCategory() => View();
        [HttpPost]
        public IActionResult DeleteCategory(int KategorijaID)
        {
            if (ModelState.IsValid)
            {
                var cat = Service.GetCategoryByID(KategorijaID);
                var articles = Service.GetArticlesByCategory(cat.ImeKategorije);
                if (articles != null)
                {
                    foreach (var item in articles)
                    {
                        Service.DeleteArticle(item.ArtiklID);
                    }
                }
                Service.DeleteCategory(KategorijaID);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult GetCatList(int id) => Json(Service.GetCategoryByID(id).OpisKategorije);
        [HttpGet]
        public FileResult Download(string subject, string username, string date)
        {

            var message = Service.GetMessageBoxID(subject, username, date);
            return File(message.Attachment, "image/jpeg", "image");
        }
        [HttpGet]
        public IActionResult ManageAdvertisement() => View(Service.GetAdvertisements());
        [HttpGet]
        public IActionResult AddAdvertisement() => View();
        [HttpPost]
        public async Task<IActionResult> AddAdvertisement(AdvertisementViewModel model, IFormFile picture)
        {
            if (ModelState.IsValid)
            {

                var memStream = new MemoryStream();
                picture.CopyTo(memStream);
                Service.AddAdvertisement(model, memStream.ToArray());
                var currUser = await userManager.GetUserAsync(User);
                var otherUser = await userManager.FindByNameAsync(model.UserName);
                if (currUser.Id == otherUser.Id) return RedirectToAction(nameof(AddAdvertisement));
                Service.AddMessage(currUser, otherUser, "Marketing update", "Successfully added advertisement", null);
                return View(nameof(ManageAdvertisement));
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult DeleteAdvertisement(int id)
        {
            if (ModelState.IsValid)
            {
                var model = Service.DeleteAdvertisement(id);
            }
            return View(nameof(ManageAdvertisement),Service.GetAdvertisements());
        }
        [HttpGet]
        public IActionResult ChangeAdvertisement(int id)
        {
            var model = Service.GetAdvertisement(id);
            var viewModel = new AdvertisementViewModel
            {
                Description = model.Description,
                ExpirationDate = model.ExpirationDate,
                RegistrationDate = model.RegistrationDate,
                Image = model.Image,
                TypeName = Service.GetAdvertisementType(model.AdvertisementTypeID).TypeName,
                UserName = Service.GetUserByID(model.AppUserId).UserName
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult ChangeAdvertisement(AdvertisementViewModel model,IFormFile image)
        {
            if (image != null)
            {
                var memStream = new MemoryStream();
                image.CopyTo(memStream);
                model.Image = memStream.ToArray();
            }
                var ad = Service.GetAdvertisementByNameUser(model.TypeName,model.UserName,model.RegistrationDate.ToString());
                Service.ChangeExpirationDate(ad.AdvertisementId,model);
                return RedirectToAction(nameof(ManageAdvertisement));
        }
        [HttpGet]
        public IActionResult AddAdvertisementType() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAdvertisementType(AdvertisementTypeViewModel model)
        {
            if (ModelState.IsValid)
            {

                Service.AddAdvertisementType(model);
                return RedirectToAction(nameof(AddAdvertisementType));
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DeleteAdvertisementType(string name) {
            if (ModelState.IsValid)
            {
               
                var res =Service.GetAdvertisementTypeByName(name);
                Service.DeleteAdvertisementType(res.AdTypeId);
            }

            return RedirectToAction(nameof(AddAdvertisementType));
        }

        [HttpPost]
        public async Task<IActionResult> ChangePicture(IFormFile attachment)
        {
            if (attachment == null)
            {
                return NotFound();
            }
            var ms = new MemoryStream();
            attachment.CopyTo(ms);
            var crntUser = await userManager.GetUserAsync(User);
            Service.ChangePicture(crntUser.Id,ms.ToArray());
            return Json(string.Format("data:image/png;base64,{0}", Convert.ToBase64String(crntUser.Picture)));
;        }
    }
}

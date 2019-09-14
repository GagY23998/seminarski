using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShopping.Controllers;
using OnlineShopping.Data;
using OnlineShopping.HelperUser;
using OnlineShopping.Models;
using OnlineShopping.Services;
using OnlineShopping.ViewModels;
using OnlineShoppTestProject.HelperTestClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace OnlineShoppTestProject
{
    [TestClass]
    public class AdminControllerTests
    {
        public Mock<FakeUserManager> mockUserManager { get; set; }
        public Mock<FakeSignInManager> MockSignInManager { get; set; }
        public Mock<ArtikliService> mockService { get; set; }
        public Mock<FakeRoleManager> mockRoleManager { get; set; }
        public ApplicationDbContext context { get; set; }
        public AdminController controller { get; set; }
        [TestInitialize]
        public void initialize()
        {
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>().
                UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            context = new ApplicationDbContext(options);

            mockUserManager = new Mock<FakeUserManager>();
            MockSignInManager = new Mock<FakeSignInManager>();
            mockService = new Mock<ArtikliService>(MockBehavior.Strict, context);
            mockRoleManager = new Mock<FakeRoleManager>();
            controller = new AdminController(mockService.Object, MockSignInManager.Object,
                                                mockUserManager.Object,
                                                mockRoleManager.Object);
        }
        [TestCleanup]
        public void clean()
        {
            //foreach(var item in context.Model.GetEntityTypes().Select(m=>m.FindPrimaryKey().Properties[0])
            //{
            //    item.
            //}
            context.Database.EnsureDeleted();
            context.Dispose();
            mockUserManager.Reset();
            MockSignInManager.Reset();
            mockRoleManager.Reset();
            mockService.Reset();
            controller.Dispose();
        }

        [TestMethod]
        public async Task AddArticle_ModelNotValid_ReturnIndex()
        {
            //Arrange

            context.Categories.Add(new Kategorija { ImeKategorije = "Obuca" });
            context.SaveChanges();



            //var user = new AppUser { Email = "email@hotmail.com", UserName = "user123" };
            //var password = "Pass1234@";

            //      var controller = new AdminController(mockService.Object, mockSignInManager.Object, mockUserManager.Object, mockRoleManager.Object);
            //Act
            var article = new OnlineShopping.ViewModels.ArtiklOneViewModel { ImeArtikla = null, ImeKategorije = null };
            controller.ModelState.AddModelError("Greska", "Error for no reason");

            var result = await controller.AddArticle(article, null);
            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public async Task AddArticle_ModelIsValid_ReturnRedirectToAction()
        {
            //Arrange
            //    var controller = new AdminController(mockService.Object, mockSignInManager.Object, mockUserManager.Object, mockRoleManager.Object);

            context.Categories.Add(new Kategorija { ImeKategorije = "Obuca" });
            context.SaveChanges();
            ArtiklOneViewModel viewModel = new ArtiklOneViewModel
            {
                ImeArtikla = "DobarArtikl",
                NaStanju = 10,
                CijenaArtikla = 242.21M,
                ImeKategorije = "Obuca"
            };
            //Act
            var result = await controller.AddArticle(viewModel, null);
            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }
        [TestMethod]
        public void AddCategory_ModelIsValid_ReturnAddCategoryView()
        {
            //      var controller = new AdminController(mockService.Object, mockSignInManager.Object, mockUserManager.Object, mockRoleManager.Object);
            //Act
            controller.ModelState.AddModelError("Error", "Nevalidan model");
            var viewName = controller.AddCategory(new KategorijaViewModel { }) as ViewResult;
            //Assert
            Assert.IsInstanceOfType(viewName, typeof(ViewResult));
            Assert.AreSame(viewName.ViewName, "AddCategory");
        }
        [TestMethod]
        public void AddCategory_ModelIsNotValid_ReturnRedirecToActionView()
        {
            var controller = new AdminController(mockService.Object, MockSignInManager.Object, mockUserManager.Object, mockRoleManager.Object);
            //Act
            var viewName = controller.AddCategory(new KategorijaViewModel { ImeKategorije = "Cizma" });
            //Assert
            Assert.IsInstanceOfType(viewName, typeof(RedirectToActionResult));
        }
        [TestMethod]
        public void AddCategory_ArticlesAreNotEmpty_ReturnNonEmptyViewData()
        {
            //Arrange
            //    var controller = new AdminController(mockService.Object, mockSignInManager.Object, mockUserManager.Object, mockRoleManager.Object);
            controller.Service.CreateArticle(new Artikl { ImeArtikla = "Dukserica", VrijemePostavlanja = new DateTime(1990, 1, 1), NaStanju = 10, CijenaArtikla = 6180.50M });
            controller.Service.CreateArticle(new Artikl { ImeArtikla = "Majica", VrijemePostavlanja = new DateTime(1990, 1, 1), NaStanju = 30, CijenaArtikla = 32.23M });

            var theList = new List<Artikl> {
                new Artikl{ImeArtikla="Dukserica",VrijemePostavlanja=new DateTime(1990,1,1),NaStanju=10,CijenaArtikla=6180.50M},
                new Artikl{ImeArtikla="Majica",VrijemePostavlanja=new DateTime(1990,1,1),NaStanju=30,CijenaArtikla=32.23M}
                };
            //Act

            var result = controller.DeleteArticle() as ViewResult;
            List<Artikl> artikls = result.Model as List<Artikl>;

            //Assert
            CollectionAssert.AreEqual(artikls, theList, Comparer<Artikl>.
                             Create((fEl, sEl) => String.Compare(fEl.ImeArtikla, sEl.ImeArtikla) == 0 &&
                                              DateTime.Compare(fEl.VrijemePostavlanja, sEl.VrijemePostavlanja) == 0 &&
                                               fEl.NaStanju == sEl.NaStanju &&
                                               fEl.CijenaArtikla.CompareTo(sEl.CijenaArtikla) == 0 ? 0 : 1));
        }
        [TestMethod]
        public void AddCategory_ArticlesAreEmpty_ReturnEmptyViewData()
        {
            //Arrange
            //     var controller = new AdminController(mockService.Object, mockSignInManager.Object, mockUserManager.Object, mockRoleManager.Object);
            //Act 
            var result = controller.DeleteArticle() as ViewResult;
            var data = result.Model as List<Artikl>;
            //Assert
            Assert.AreEqual(0, data.Count);

        }
        [TestMethod]
        public void ChangeArticleGet_PassedIdIsNotNull_ReturnViewChangeArticleWithModel()
        {
            //       var controller = new AdminController(mockService.Object, mockSignInManager.Object, mockUserManager.Object, mockRoleManager.Object);
            controller.Service.AddCategory(new Kategorija { ImeKategorije = "Obuca" });
            controller.Service.CreateArticle(new Artikl
            {
                ImeArtikla = "Papuce",
                VrijemePostavlanja = new DateTime(2012, 12, 12),
                NaStanju = 10,
                CijenaArtikla = 2523.21M,
                KategorijaID = 1
            });
            var myArtikl = new Artikl
            {
                ImeArtikla = "Papuce",
                VrijemePostavlanja = new DateTime(2012, 12, 12),
                NaStanju = 10,
                CijenaArtikla = 2523.21M,
                KategorijaID = mockService.Object.GetCategory("Obuca").KategorijaID
            };

            var result = controller.ChangeArticle(mockService.Object.GetArticleIDbyName("Papuce")) as ViewResult;
            var model = result.Model as Artikl;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(model.ImeArtikla, myArtikl.ImeArtikla);
            Assert.AreEqual(model.NaStanju, myArtikl.NaStanju);
            Assert.AreEqual(model.CijenaArtikla, myArtikl.CijenaArtikla);
        }
        [TestMethod]
        public void ChangeArticleGet_PassedIdIsNull_ReturnRedirectToAction()
        {
            //Arrange
            //          var controller = new AdminController(mockService.Object, mockSignInManager.Object, mockUserManager.Object, mockRoleManager.Object);
            //Act
            var result = controller.ChangeArticle(0);

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }
        [TestMethod]
        public void ChangeArticlePost_PassedValidParamaters_ReturnViewResult()
        {
            //Arrange
            //          var controller = new AdminController(mockService.Object, mockSignInManager.Object, mockUserManager.Object, mockRoleManager.Object);
            Mock<IFormFile> fakeFormFile = new Mock<IFormFile>();
            var sadrzaj = "This is fake sadrzaj";
            var imeFajla = "temp.pdf";
            var ms = new MemoryStream();
            var streamWriteer = new StreamWriter(ms);
            streamWriteer.Write(sadrzaj);
            streamWriteer.Flush();
            ms.Position = 0;
            fakeFormFile.Setup(mock => mock.OpenReadStream()).Returns(ms);
            fakeFormFile.Setup(mock => mock.FileName).Returns(imeFajla);
            fakeFormFile.Setup(mock => mock.Length).Returns(ms.Length);
            string imeKategorije = "Obuca";
            mockService.Object.AddCategory(new Kategorija { ImeKategorije = imeKategorije });
            mockService.Object.CreateArticle(new Artikl { ImeArtikla = "Patike", CijenaArtikla = 100.50M, NaStanju = 10, VrijemePostavlanja = DateTime.Now });
            var myArtikl = new Artikl
            {
                ArtiklID = mockService.Object.GetArticleIDbyName("Patike"),
                KategorijaID = mockService.Object.GetCategory("Obuca").KategorijaID,
                ImeArtikla = "Patike",
                CijenaArtikla = 150.50M,
                NaStanju = 15,
                VrijemePostavlanja = DateTime.Now.AddDays(10)
            };
            //Act
            var result = controller.ChangeArticle(myArtikl, fakeFormFile.Object, imeKategorije);
            //Assert

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }
        [TestMethod]
        public void ChangeArticlePost_PassedInvalidParameter_ReturnRedirectToActionResult()
        {
            //Arrange
            //          var controller = new AdminController(mockService.Object, mockSignInManager.Object, mockUserManager.Object, mockRoleManager.Object);
            Mock<IFormFile> fakeFormFile = new Mock<IFormFile>();
            var sadrzaj = "This is fake sadrzaj";
            var imeFajla = "temp.pdf";
            var ms = new MemoryStream();
            var streamWriteer = new StreamWriter(ms);
            streamWriteer.Write(sadrzaj);
            streamWriteer.Flush();
            ms.Position = 0;
            fakeFormFile.Setup(mock => mock.OpenReadStream()).Returns(ms);
            fakeFormFile.Setup(mock => mock.FileName).Returns(imeFajla);
            fakeFormFile.Setup(mock => mock.Length).Returns(ms.Length);
            mockService.Object.AddCategory(new Kategorija { ImeKategorije = "Obuca" });

            mockService.Object.CreateArticle(new Artikl { ImeArtikla = "Patike", CijenaArtikla = 100.50M, NaStanju = 10, VrijemePostavlanja = DateTime.Now });
            var myArtikl = new Artikl
            {
                ArtiklID = 1,
                KategorijaID = 1,
                ImeArtikla = "Patike",
                CijenaArtikla = 150.50M,
                NaStanju = 15,
                VrijemePostavlanja = DateTime.Now.AddDays(10)
            };
            //Act

            var result = controller.ChangeArticle(new Artikl { ImeArtikla = "Patike", CijenaArtikla = 120.3M, NaStanju = 20, VrijemePostavlanja = DateTime.Now.AddDays(-1) }, fakeFormFile.Object, null);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void GetArticles_PassedWrongCategory_ReturnViewResult()
        {
            mockService.Object.AddCategory(new Kategorija { ImeKategorije = "Obuca" });
            //Act
            var result = controller.GetArticles("PogresnaPretraga");
            var viewName = result as ViewResult;
            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual("Index", viewName.ViewName);
        }
        [TestMethod]
        public void GetArticles_PassedCorrectCategory_ReturnPartialViewResultWithData()
        {
            //Arrange
            mockService.Object.AddCategory(new Kategorija { ImeKategorije = "Obuca" });
            //Act
            var result = controller.GetArticles("Obuca") as PartialViewResult;
            var articles = result.Model as List<Artikl>;
            //Assert
            Assert.IsInstanceOfType(result, typeof(PartialViewResult));
            Assert.AreEqual(0, articles.Count);
        }
        [TestMethod]
        public void SeeArticleHistory_ValidParameter_ReturnPartialViewWithData()
        {
            //Arrange
            mockService.Object._context.Users.Add(new AppUser { Email = "email@hotmail.com", UserName = "user123" });
            mockService.Object.CreateArticle(new Artikl { ImeArtikla = "Patike", NaStanju = 10, CijenaArtikla = 30.25M, VrijemePostavlanja = DateTime.Now });
            mockService.Object._context.BuyingHistory.Add(new ArticleBuyingHistory
            {
                UserID = mockService.Object.GetUser("email@hotmail.com").Id,
                Quantity = 100,
                PurchaseDate = DateTime.Now,
                ArtiklID = mockService.Object.GetArticleIDbyName("Patike")
            });

            //Act
            var result = controller.SeeArticleHistory("Patike") as PartialViewResult;
            var model = result.Model as List<ArticlePurchaseHistoryViewModel>;
            //Assert
            Assert.IsInstanceOfType(result, typeof(PartialViewResult));
            Assert.IsTrue(model.Count == 0);
        }
        [TestMethod]
        public void UpdateQuantityGet_DataToReturnIsValid_ViewWithValidData()
        {
            //Arrange 

            mockService.Object.CreateArticle(new Artikl { ImeArtikla = "Patike", NaStanju = 10, CijenaArtikla = 30.25M, VrijemePostavlanja = new DateTime(2012, 12, 22) });
            mockService.Object.CreateArticle(new Artikl { ImeArtikla = "Papuce", NaStanju = 210, CijenaArtikla = 305.25M, VrijemePostavlanja = new DateTime(2012, 12, 22).AddDays(2) });
            var alreadaAddedArticles = new List<Artikl>
            {
                new Artikl { ImeArtikla = "Papuce", NaStanju = 210, CijenaArtikla = 305.25M, VrijemePostavlanja =  new DateTime(2012,12,22).AddDays(2)},
                new Artikl { ImeArtikla = "Patike", NaStanju = 10, CijenaArtikla = 30.25M, VrijemePostavlanja =  new DateTime(2012,12,22) }
            };
            //Act
            var result = controller.UpdateQuantity() as ViewResult;
            var model = result.Model as List<Artikl>;
            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsTrue(model.Count != 0);
            CollectionAssert.AreEqual(alreadaAddedArticles, model, Comparer<Artikl>.Create((fEl, sEl) => fEl.ImeArtikla == sEl.ImeArtikla
              && fEl.NaStanju == sEl.NaStanju && fEl.CijenaArtikla == sEl.CijenaArtikla && fEl.VrijemePostavlanja == sEl.VrijemePostavlanja ? 0 : 1));
        }
        [TestMethod]
        public void UpdateQuantityGet_DataToReturnIsNotValid_ContentResult()
        {
            //Act
            var result = controller.UpdateQuantity() as ViewResult;
            var model = result.Model as List<Artikl>;
            //Assert
            Assert.IsTrue(model.Count == 0);
        }
        [TestMethod]
        public void UpdateQuantityPost_PassedParameterisValid_ReturnRedirectToActionResult()
        {
            mockService.Object.CreateArticle(new Artikl { ImeArtikla = "Patike", NaStanju = 10, CijenaArtikla = 30.25M, VrijemePostavlanja = new DateTime(2012, 12, 22) });
            mockService.Object.CreateArticle(new Artikl { ImeArtikla = "Papuce", NaStanju = 210, CijenaArtikla = 305.25M, VrijemePostavlanja = new DateTime(2012, 12, 22).AddDays(2) });
            var newQuantities = new List<Artikl>
            {
                new Artikl { ArtiklID = mockService.Object.GetArticleIDbyName("Papuce"), ImeArtikla = "Papuce", NaStanju = 5, CijenaArtikla = 305.25M, VrijemePostavlanja =  new DateTime(2012,12,22).AddDays(2)},
                new Artikl { ArtiklID = mockService.Object.GetArticleIDbyName("Patike") ,ImeArtikla = "Patike", NaStanju = 2, CijenaArtikla = 30.25M, VrijemePostavlanja =  new DateTime(2012,12,22) }
            };
            var result = controller.UpdateQuantity(newQuantities);
            var data = mockService.Object.GetArticles().ToList();
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            CollectionAssert.AreEqual(data, newQuantities, Comparer<Artikl>.Create((fEl, sEl) =>
                fEl.ImeArtikla == sEl.ImeArtikla &&
                fEl.NaStanju == sEl.NaStanju ? 0 : 1));
        }
        [TestMethod]
        public void UpdateQuantityPost_PassedParameterisValid_ReturnContentResult()
        {
            controller.ModelState.AddModelError("Greska", "Nevalidan parametar");
            //Act
            var result = controller.UpdateQuantity(null);
            //Assert
            Assert.IsInstanceOfType(result, typeof(ContentResult));
        }
        [TestMethod]
        public async Task GetMessage_UserIsValid_ReturnMessages()
        {
            //Arrange
            var user = new AppUser {/*Id="id1",*/ FirstName = "Ime", LastName = "Prezime", Email = "imePrezime@email.com", UserName = "ime123" };
            mockUserManager.Setup(_ => _.CreateAsync(user, "pass123")).ReturnsAsync(IdentityResult.Success);
            var mockClaimPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimPrincipal.Setup(_ => _.HasClaim(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(_ => _.User).Returns(mockClaimPrincipal.Object);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = mockHttpContext.Object;
            mockUserManager.Setup(_ => _.GetUserAsync(controller.User)).ReturnsAsync(user);
            var user2 = new AppUser { FirstName = "Test", LastName = "Testic", Email = "testy@email.com", UserName = "test123" };
            Mock<IFormFile> fakeFormFile = new Mock<IFormFile>();
            var sadrzaj = "This is fake sadrzaj";
            var imeFajla = "temp.pdf";
            var ms = new MemoryStream();
            var streamWriteer = new StreamWriter(ms);
            streamWriteer.Write(sadrzaj);
            streamWriteer.Flush();
            ms.Position = 0;
            fakeFormFile.Setup(mock => mock.OpenReadStream()).Returns(ms);
            fakeFormFile.Setup(mock => mock.FileName).Returns(imeFajla);
            fakeFormFile.Setup(mock => mock.Length).Returns(ms.Length);
            mockUserManager.Setup(_ => _.CreateAsync(user2, "testtest")).ReturnsAsync(IdentityResult.Success);
 
            //Act
            context.Users.AddRange(user, user2);
            context.SaveChanges();
            context.MessageBoxes.Add(new MessageBox
            {
                ReciverID = user.Id,
                SenderID = user2.Id,
                Subject = "Poruka",
                Message = "Sta ima",
                CreationDate = DateTime.Now,
                IsRead = false
            });
            context.SaveChanges();
            var result = controller.GetMessage().Result;
            var model = result as ViewResult;
            var data = model.Model as List<MessageBox>;
            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsTrue(data.Count != 0);

        }
        [TestMethod]
        public void GetMessage_UserIsInvalid_ReturnRedirectToAction()
        {
            //Arrange
            var claimPrincipal = new ClaimsPrincipal();
            var controllerContext = new ControllerContext();
            controller.ControllerContext = controllerContext;
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(_ => _.User).Returns(claimPrincipal);
            controller.ControllerContext.HttpContext = mockHttpContext.Object;
            controller.HttpContext.User = claimPrincipal;
            mockUserManager.Setup(_ => _.GetUserAsync(controller.User)).ReturnsAsync(new AppUser
            {
                FirstName = "Ime",
                LastName = "Prezime",
                UserName = "imeprezime"
            });
            //Act
            var result = controller.GetMessage().Result;
            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }
    }
}

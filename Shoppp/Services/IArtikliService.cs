using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopping.ViewModels;
using OnlineShopping.HelperUser;
using Microsoft.AspNetCore.Http;

namespace OnlineShopping.Services
{
    public interface IArtikliService
    {
        int GetArticleIDbyName(string name);
        Artikl CreateArticle(Artikl noviArtikl);
        Artikl ChangeArticle(int articleID,Artikl noviArtikl);
        Artikl DeleteArticle(int articleID);
        IEnumerable<Artikl> GetArticles();
        Kategorija AddCategory(Kategorija kategorija);
        Kategorija DeleteCategory(int kategorijaID);
        Kategorija GetCategory(string imeKategorije);
        Kategorija GetCategoryByID(int id);
        Artikl GetArticle(int articleID);
        IEnumerable<Artikl> GetArticlesByCategory(string pretraga);
        IEnumerable<ArticlePurchaseHistoryViewModel> GetSoldArticles(int ArticleID);
        IEnumerable<Kategorija> GetCategories();
        AppUser GetUser(string email);
        AppUser GetUserByID(string id);
        void AddMessage(AppUser sender,AppUser reciever,string subject,string message,IFormFile attachment);
        int GetUnreadMessages(string userID);
        List<MessageBox> GetMessages(string name);
        void MarkAsRead(int id);
        MessageBox GetMessage(int id);
        bool GetMessageByName(string subject, string username,DateTime creationDate);
        MessageBox GetMessageBoxID(string subject, string username, string date);
        List<ArtiklOneViewModel> ArticlesExpire();
        IEnumerable<AppUser> GetUsers();
        Advertisement AddAdvertisement(AdvertisementViewModel viewModel,byte[]picture);
        Advertisement DeleteAdvertisement(int id);
        Advertisement ChangeExpirationDate(int id,AdvertisementViewModel model);
        AdvertisementType AddAdvertisementType(AdvertisementTypeViewModel viewModel);
        List<AdvertisementViewModel> GetAdvertisements();
        AdvertisementType DeleteAdvertisementType(int id);
        Advertisement GetAdvertisementByNameUser(string typename,string username,string date);
        Advertisement GetAdvertisement(int id);
        AdvertisementType GetAdvertisementType(int id);
        List<AdvertisementTypeViewModel> GetAdvertisementTypeModels();
        AdvertisementType GetAdvertisementTypeByName(string name);
        void ChangePicture(string UserID,byte[] pic);
    }
}

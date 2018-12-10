using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopping.ViewModels;

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
        Kategorija GetKategorija(string imeKategorije);
        Artikl GetArticle(int articleID);
        IEnumerable<Artikl> GetArticlesByCategory(string pretraga);
        IEnumerable<ArticlePurchaseHistoryViewModel> GetSoldArticles(int ArticleID);
    }
}

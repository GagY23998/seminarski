using Microsoft.AspNetCore.Http.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineShopping.Models;
using System;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingTestProject.Services
{
    [TestClass]
    public class ArticleServicesTests
    {
        [TestMethod]
        public void AddArticle_ModelNotValid_ReturnAddArticle()
        {
            //Arrange
            var mockArticle = new Mock<ViewResult>()
            mockArticle.Setup(mA=>mA.)
            //Result

            var result = null;
            //Assert

        }
    }
}

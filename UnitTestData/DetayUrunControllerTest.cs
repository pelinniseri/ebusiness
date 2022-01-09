using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using EBusiness.Data.Models;
using EBusiness.Repositories;
using Moq;
using EBusiness.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EbuisnessUnitTest
{
    public class DetayUrunControllerTest
    {
        [Fact]
        public void Finding_a_Product_from_the_mock_database_and_display_info()
        {
            //arrange
            Mock<Context> context_mock = new Mock<Context>();

            //Mock<ProductRepository> productRepoMock=new Mock<ProductRepository>();      // we can't use a mock of this generic class...
            var repo = new Mock<ProductRepository>(); //so we create a mock of the original abstrack class adn we implement the TAdd function. 
            Product pr = new Product();
            pr.ProductName = "the product ";
            pr.Price = 999;
            pr.ProductID = 090;
            pr.ImageUrl = "klsadf";
            pr.Stock = 9;
            pr.Category = new Category() { CategoryName = "osoadf", CategoryID = 99 };
            pr.CategoryID = 99;
            pr.Description = "sadlfasdflas;df";
            Product second_Product = pr;
            repo.Setup(
                r =>
                r.TAdd(It.IsAny<Product>())).Returns(true)
                ;
            repo.Setup(r => r.TFind(It.IsAny<int>())).Returns(pr);
            DetayUrun du = new DetayUrun(context_mock.Object, repo.Object);
            int id = pr.ProductID;
            //act             
            Product product_in_Repo = repo.Object.TFind(id);
            //assert
            Assert.True(id== product_in_Repo.ProductID);
        }
    }

}

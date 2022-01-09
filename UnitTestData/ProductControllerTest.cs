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
   
    public class ProductControllerTest
    {
         
        public ProductControllerTest()
        {
            
        }
        [Fact]
        public void Adding_a_Product_to_the_mock_database_and_Redirect()
        {
            //arrange
            Mock<Context> context_mock = new Mock<Context>();

            //Mock<ProductRepository> productRepoMock=new Mock<ProductRepository>();      // we can't use a mock of this generic class...
            var repo = new Mock<ProductRepository>(); //so we create a mock of the original abstrack class adn we implement the TAdd function. 
            Product pr = new Product();
            pr.ProductName = "the product ";
            pr.Price = 999;
            
            repo.Setup(
                r => 
                    r.TAdd(It.IsAny<Product>())).Returns(true)
                ;
            ProductController pc = new ProductController(context_mock.Object, repo.Object);
            //act 
            ActionResult result = (ActionResult) pc.ProductAdd(pr);
            //repo
            //assert
            Assert.IsType<RedirectToActionResult>(result);
        }
        [Fact]
        public async Task Adding_a_Product_to_the_mock_database()
        {
            //arrange
            Mock<Context> context_mock = new Mock<Context>();

            //Mock<ProductRepository> productRepoMock=new Mock<ProductRepository>();      // we can't use a mock of this generic class...
            var repo = new Mock<ProductRepository>(); //so we create a mock of the original abstrack class adn we implement the TAdd function. 
            Product pr = new Product();
            pr.ProductName = "the product ";
            pr.Price = 999;

            repo.Setup(
                r =>
                    r.TAdd(It.IsAny<Product>())).Returns(true)
                ;
            ProductController pc = new ProductController(context_mock.Object, repo.Object);

            //act 
            ActionResult action = (ActionResult)pc.ProductAdd(pr);
            
            //assert
            Assert.NotNull(action);
        }

    }
}

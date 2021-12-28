using EBusiness.Data.Models;
using EBusiness.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBusiness.ViewComponents
{
    public class ProductInDetay:ViewComponent
    {

        public IViewComponentResult Invoke(int id)
        {

            ProductRepository productRepository = new ProductRepository();

            var x = productRepository.TFind(id);

          
            Product prdct = new Product()
            {
                ProductID = x.ProductID,
                CategoryID = x.CategoryID,
                ProductName = x.ProductName,
                Price = x.Price,
                Stock = x.Stock,
                Description = x.Description,
                ImageUrl = x.ImageUrl,

            };

           
            return View(prdct);
        }
    }
}

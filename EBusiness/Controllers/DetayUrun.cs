using EBusiness.Data.Models;
using EBusiness.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBusiness.Controllers
{
    public class DetayUrun : Controller
    {
        public DetayUrun(Context cx,ProductRepository pr)
        {
            this.c = cx;
            this.productRepository = pr;
        }
        public DetayUrun() { }

        ProductRepository productRepository = new ProductRepository();
        Context c = new Context();
        public IActionResult Index(int id)
        {

            
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

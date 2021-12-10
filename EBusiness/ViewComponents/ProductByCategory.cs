using EBusiness.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBusiness.ViewComponents
{
    public class ProductByCategory:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
          
            ProductRepository productRepository = new ProductRepository();
            var productlist = productRepository.List(x=> x.CategoryID==id);
            return View(productlist);
        }
    }
}

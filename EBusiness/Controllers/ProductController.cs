using EBusiness.Data.Models;
using EBusiness.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBusiness.Controllers
{
    public class ProductController : Controller
    {
        Context c = new Context();
        ProductRepository productRepository = new ProductRepository();
        public IActionResult Index()
        {
            
            
            
            return View(productRepository.TList("Category"));
        }

        [HttpGet]
        public IActionResult ProductAdd()
        {
            List<SelectListItem> values=(from x in c.Categories.ToList()
                                         select new SelectListItem { 
                                            Text=x.CategoryName,
                                            Value=x.CategoryID.ToString(),
                                         }).ToList();
            ViewBag.v1 = values;
            return View();
        }

        [HttpPost]
        public IActionResult ProductAdd(Product pr)
        {
            productRepository.TAdd(pr);
            return RedirectToAction("Index");
        }
    }
}

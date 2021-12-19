using EBusiness.Data.Models;
using EBusiness.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;


namespace EBusiness.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        Context c = new Context();
        ProductRepository productRepository = new ProductRepository();
        public IActionResult Index(int page=1)
        {
            
            
            
            return View(productRepository.TList("Category").ToPagedList(page,3));
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
            //Product product = new Product();
            //if (pr.ImageUrl != null)
            //{
            //    var extension = Path.GetExtension(pr.ImageUrl.FileName);
            //    var newimagename = Guid.NewGuid() + extension;
            //    var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Photos/",newimagename);
            //    var stream = new FileStream(location, FileMode.Create);
            //    pr.ImageUrl.CopyTo(stream);
            //    product.ImageUrl = newimagename;

            //}
            //product.ProductName = pr.ProductName;
            //product.Price = pr.Price;
            //product.Stock = pr.Stock;
            //product.CategoryID = pr.CategoryID;
            //product.Description = pr.Description;
            
            productRepository.TAdd(pr);
            return RedirectToAction("Index");
        }

        public IActionResult ProductDelete(int id)
        {
            productRepository.TDelete(new Product { ProductID = id });

            return RedirectToAction("Index");
        }

        public IActionResult ProductGet(int id)
        {
            var x = productRepository.TFind(id);

            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.v1 = values;
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

        [HttpPost]
        public IActionResult ProductUpdate(Product product)
        {
            var x = productRepository.TFind(product.ProductID);
            x.ProductName = product.ProductName;
            x.Price = product.Price;
            x.ImageUrl = product.ImageUrl;
            x.Stock = x.Stock;
            x.Description = product.Description;
            x.CategoryID = product.CategoryID;
            productRepository.TUpdate(x);
            return RedirectToAction("Index");

        }
    }
}

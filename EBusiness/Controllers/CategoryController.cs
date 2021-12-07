using EBusiness.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EBusiness.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace EBusiness.Controllers
{
    
   
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
       
        [Authorize]
        public IActionResult Index()
        {
            
            return View(categoryRepository.TList());
        }
        [Authorize]
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();

        }
        [Authorize]
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            p.Status = true;
            categoryRepository.TAdd(p);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepository.TFind(id);
            Category ct = new Category()
            {
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription,
                CategoryID = x.CategoryID,

            };
            return View(ct);
        }
        [Authorize]
        [HttpPost]
        public IActionResult CategoryUpdate(Category ctgry)
        {
            var x = categoryRepository.TFind(ctgry.CategoryID);
            x.CategoryName = ctgry.CategoryName;
            x.CategoryDescription = ctgry.CategoryDescription;
            x.Status = ctgry.Status;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult CategoryDelete(int id)
        {
            var x = categoryRepository.TFind(id);
            x.Status = false;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}

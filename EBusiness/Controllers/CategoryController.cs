using EBusiness.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EBusiness.Data.Models;
namespace EBusiness.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index()
        {
            
            return View(categoryRepository.TList());
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();

        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            categoryRepository.TAdd(p);
            return View();
        }
    }
}

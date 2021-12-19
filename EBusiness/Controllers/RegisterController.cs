using EBusiness.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBusiness.Controllers
{
    public class RegisterController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterUser(User p)
        {
            c.Users.Add(p);
            p.Durum = true;
            p.Role = "User";
            c.SaveChanges();
            return RedirectToAction("Index","Login");
        }


    }
}

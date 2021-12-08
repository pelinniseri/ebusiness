using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace EBusiness.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            var user = User.Identity.Name;
            if (user == null)
            {
                ViewBag.d1 = "No user logged in.";
                return View();
            }
            ViewBag.d1 = $"Name of user: {User.Identity.Name}. {(User.IsInRole("Admin") ? "\nUser is an admin!" : "")}";
            return View();
        }
    }
}

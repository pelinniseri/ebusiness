using EBusiness.Areas.Identity.Data;
using EBusiness.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EBusiness.Controllers
{
    
    public class LoginController : Controller
    {
        Context c = new Context();
        
        
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(EBusinessUser p)
        {
            var deger = c.Users.FirstOrDefault(x => x.Email == p.Email &&
              x.Password == p.Password);

            if(deger!= null)
            {
                HttpContext.Session.SetString("Email", p.Email);
                return RedirectToAction("Index", "Contact");
            }
            return View();
        }

        [HttpGet]
        public IActionResult AdminIndex()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> AdminIndex(Admin p)
        {
            var datavalue = c.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if (datavalue != null)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.Username)
                };

                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Category");
            }

            return View();
        }



        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("AdminIndex", "Login");
        }

        [HttpGet]
        public async Task<IActionResult> LogOutForUser()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}

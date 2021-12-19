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

        [HttpGet]
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(User p)
        {
            if(!string.IsNullOrEmpty(p.UserSifre) && string.IsNullOrEmpty(p.UserMail))
            {
                return RedirectToAction("Index", "Login");
            }
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;

            var deger = c.Users.FirstOrDefault(x => x.UserMail == p.UserMail &&
              x.UserSifre == p.UserSifre && x.Role=="Admin");
            var deger2 = c.Users.FirstOrDefault(x => x.UserMail == p.UserMail &&
              x.UserSifre == p.UserSifre && x.Role == "User");

            if (deger != null)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, p.UserMail),
                    new Claim(ClaimTypes.Role,"Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
               
            }


            if (deger2 != null)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, p.UserMail),
                    new Claim(ClaimTypes.Role,"User")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
            }

            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Contact");
            }
            return RedirectToAction("Index", "Login");

            //if(deger!= null)
            //{
            //    HttpContext.Session.SetString("UserMail", p.UserMail);
            //    return RedirectToAction("Index", "Contact");
            //}
            //return View();


        }

        //[HttpGet]
        //public IActionResult AdminIndex()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public async Task<IActionResult> AdminIndex(Admin p)
        //{
        //    var datavalue = c.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
        //    if (datavalue != null)
        //    {

        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name,p.Username)
        //        };

        //        var useridentity = new ClaimsIdentity(claims, "Login");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //        await HttpContext.SignInAsync(principal);
        //        return RedirectToAction("Index", "Category");
        //    }

        //    return View();
        //}



        [HttpGet]
        public async Task<IActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public async Task<IActionResult> LogOutForUser()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}

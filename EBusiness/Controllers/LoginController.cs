using EBusiness.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EBusiness.Controllers
{
    
    public class LoginController : Controller
    {
        private string code = null;
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
        
        
        
        
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgetPassword()
        {
            return View();

        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword()
        {
            return View();

        }

        public string getCode()
        {
            if (code == null)
            {
                Random rand = new Random();
                code = "";
                for(int i = 0; i < 6; i++)
                {
                    char tmp = Convert.ToChar(rand.Next(48, 58));
                    code += tmp;
                }
            }
            return code;
        }

        public IActionResult SendCode(string UserMail)
        {
            var user = c.Users.FirstOrDefault(x => x.UserMail.Equals(UserMail));
            if (user != null)
            {
                c.Add(new PasswordCode { Userid = user.Userid, Code = getCode() });
                c.SaveChanges();
                string text = "<h1>Sıfırlama için kodunuz:</h1>" + getCode() + " ";
                string subject = "Parola sifirlama";
                MailMessage msg = new MailMessage("firmalogoinf@gmail.com", UserMail,subject,text);
                msg.IsBodyHtml = true;
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.UseDefaultCredentials = false;
                NetworkCredential cre = new NetworkCredential("firmalogoinf@gmail.com", "555K1818p..pp");
                sc.Credentials = cre;
                sc.EnableSsl = true;
                sc.Send(msg);
                return RedirectToAction("ResetPassword");
            }

            return RedirectToAction("Index");
        }
       
        public IActionResult ResetPasswordCode(string code,string UserSifre)
        {
            var passwordcode = c.PasswordCodes.FirstOrDefault(x => x.Code.Equals(code));
            if (passwordcode != null)
            {
                var user = c.Users.Find(passwordcode.Userid);
                user.UserSifre = UserSifre;
                c.Update(user);
                c.Remove(passwordcode);
                c.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}

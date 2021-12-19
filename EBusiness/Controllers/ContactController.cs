using EBusiness.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBusiness.Controllers
{
    public class ContactController : Controller
    {
        Context c = new Context();
        [AllowAnonymous]
        public IActionResult Index()
        {

            return View();
        }

        [AllowAnonymous]
        public IActionResult CategoryDetails(int id)
        {
            ViewBag.x = id;
            return View();
        }

        //public IActionResult GetKonto(int id)
        //{

        //    var usermail = User.Identity.Name;
        //    var userid= c.Users.Where(x => x.UserMail == usermail).Select(y => y.Userid).FirstOrDefault();
        //    var values = c.Users.Find(userid);
        //    return View(values);
        //}


        public IActionResult Konto(int id)
        {

            var user = User.Identity.Name;
            ViewBag.d1 = user;
            Context c = new Context();

            //var username = c.Users.Where(x => x.UserMail == user).Select(y => y.UserAd).FirstOrDefault();
            //ViewBag.d2 = username;

            //var userid = c.Users.Where(x => x.UserMail == user).Select(y => y.Userid).FirstOrDefault();
            //ViewBag.d3 = userid;

            //var usersoyad = c.Users.Where(x => x.UserMail == user).Select(y => y.UserSoyad).FirstOrDefault();
            //ViewBag.d4 = usersoyad;

            //var usersehir = c.Users.Where(x => x.UserMail == user).Select(y => y.UserSehir).FirstOrDefault();
            //ViewBag.d5 = usersehir;

            //var usersifre = c.Users.Where(x => x.UserMail == user).Select(y => y.UserSifre).FirstOrDefault();
            //ViewBag.d6 = usersifre;

            var usermailx = User.Identity.Name;
            var useridx = c.Users.Where(x => x.UserMail == usermailx).Select(y => y.Userid).FirstOrDefault();
            var values = c.Users.Find(useridx);
            return View(values);





        }
        [HttpPost]
        public IActionResult KontoUpdate()
        {
            var usermailx = User.Identity.Name;
            
            var useridx = c.Users.Where(x => x.UserMail == usermailx).Select(y => y.Userid).FirstOrDefault();
            var username = c.Users.Where(x => x.UserMail == usermailx).Select(y => y.UserAd).FirstOrDefault();
            var values = c.Users.Find(useridx);
            
            values.UserAd=username;
            values.UserSoyad = values.UserSoyad;
            values.UserSehir = values.UserSehir;
            values.UserMail = values.UserMail;
            values.UserSifre = values.UserSifre;

           
            return RedirectToAction("Index");
        }
    }
}
﻿using EBusiness.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EBusiness.Repositories;
using EBusiness.Data;

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
        public IActionResult KontoUpdate(User usr)
        {
            var usermailx = User.Identity.Name;
            var useridx = c.Users.Where(x => x.UserMail == usermailx).Select(y => y.Userid).FirstOrDefault();
            
            //var username = c.Users.Where(x => x.UserMail == usermailx).Select(y => y.UserAd).FirstOrDefault();
            var values = c.Users.Find(useridx);
          
            values.UserAd=usr.UserAd;
            values.UserSoyad = usr.UserSoyad;
            values.UserSehir = usr.UserSehir;
            values.UserMail = usr.UserMail;
            values.UserSifre = usr.UserSifre;

            c.SaveChanges();
            return RedirectToAction("Index");
        }

   
        public IActionResult ProductDetail(int id)
        {            
            return View();
        }

        public IActionResult Cart(int id)
        {
            return View();
        }

        public IActionResult AddToCart(int id)
        {
            var cart = SessionManager.GetCart(HttpContext.Session);

            //Check if product already exists
            int index = cart.FindIndex(item => { return item.Item1 == id; });
            if(index == -1)
            {
                //Product does not exist
                cart.Add(new Tuple<int, int>(id, 1));
            }
            else
            {
                //Product already exists in cart
                var increasedProduct = new Tuple<int, int>(cart[index].Item1, cart[index].Item2 + 1);
                cart.RemoveAt(index);
                cart.Add(increasedProduct);
            }
            SessionManager.SetCart(HttpContext.Session, cart);

            return RedirectToAction("Cart");
        }

    }
}
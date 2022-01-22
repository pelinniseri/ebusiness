using EBusiness.Data.Models;
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

        public IActionResult Cart()
        {
            var cart = SessionManager.GetCart(HttpContext.Session);
            ProductRepository productRepository = new ProductRepository();

            //Calculate total price
            ViewBag.totalPrice = 0;
            foreach (var item in cart)
            {
                Product product = productRepository.TFind(item.Item1);
                ViewBag.totalPrice += product.Price * item.Item2;
            }

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
            ViewBag.card = cart;
            return RedirectToAction("Cart");
        }
        //DEGİŞİKLİK
        public IActionResult Order()
        {
            var cart = SessionManager.GetCart(HttpContext.Session);
            ViewBag.card = cart;
            ViewBag.totalPrice = 0;
            ViewBag.ItemCount = 0;
            ProductRepository productRepository = new ProductRepository();
            foreach (var item in cart)
            {
                ViewBag.ItemCount += 1;
                Product product = productRepository.TFind(item.Item1);
                ViewBag.totalPrice += product.Price * item.Item2;
            }
            return RedirectToAction("Index","Order");
        }
        public IActionResult RemoveFromCart(int id)
        {
            var cart = SessionManager.GetCart(HttpContext.Session);
            var product = cart.Find(item => { return item.Item1 == id; });
            cart.Remove(product);
            SessionManager.SetCart(HttpContext.Session, cart);

            return RedirectToAction("Cart");
        }

        public IActionResult IncreaseCartAmount(int id)
        {
            var cart = SessionManager.GetCart(HttpContext.Session);
            int index = cart.FindIndex(item => { return item.Item1 == id; });
            var increasedProduct = new Tuple<int, int>(cart[index].Item1, cart[index].Item2 + 1);
            cart.RemoveAt(index);
            cart.Add(increasedProduct);
            SessionManager.SetCart(HttpContext.Session, cart);

            return RedirectToAction("Cart");
        }

        public IActionResult DecreaseCartAmount(int id)
        {
            var cart = SessionManager.GetCart(HttpContext.Session);
            int index = cart.FindIndex(item => { return item.Item1 == id; });
            var decreasedProduct = new Tuple<int, int>(cart[index].Item1, cart[index].Item2 - 1);
            cart.RemoveAt(index);
            if(decreasedProduct.Item2 > 0)
                cart.Add(decreasedProduct);
            SessionManager.SetCart(HttpContext.Session, cart);

            return RedirectToAction("Cart");
        }

        public IActionResult EmptyCart()
        {
            var cart = SessionManager.GetCart(HttpContext.Session);
            cart.Clear();
            SessionManager.SetCart(HttpContext.Session, cart);

            return RedirectToAction("Cart");
        }
    }
}
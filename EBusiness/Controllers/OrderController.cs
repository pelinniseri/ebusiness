using EBusiness.Data;
using EBusiness.Data.Models;
using EBusiness.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EBusiness.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            
            var cart = SessionManager.GetCart(HttpContext.Session);
            ViewBag.card = cart;
            ViewBag.totalPrice = 0;
            ViewBag.ItemCount = 0;
            ProductRepository productRepository = new ProductRepository();
            foreach (var item in cart)
            {
                ViewBag.ItemCount +=item.Item2;
                Product product = productRepository.TFind(item.Item1);
                ViewBag.totalPrice += product.Price * item.Item2;
            }
            return View();
        }
        public IActionResult SendMail(Order model)
        {
            if (model != null)
            {
                string text = "<h1>Sipariş bilgileri</h1>" + "<label>" + model.FirstName + "</label>" + "<br>" + "<label>" + model.Address + "</label>" + "<label>" + model.CardNumber + "</label>"
                    + "<br>";
                text += "<br><table><thead><th>Ürün Adı</th><th> Miktar </th><th> Fiyat </th></thead><tbody>";
                var cart = SessionManager.GetCart(HttpContext.Session);
                ProductRepository productRepository = new ProductRepository();
                foreach (var item in cart)
                {
                    text += "<tr>";
                    Product product = productRepository.TFind(item.Item1);
                    text += "<td>" + product.ProductName + "</td>";
                    text += "<td>" + item.Item2 + "</td>";
                    text += "<td>" + product.Price * item.Item2 + "</td>";
                    text += "</tr>";
                }
                text += "</tbody></table><br>";
                text+="Siparişi onaylıyor musunuz?" + "<br>"+ "<a href=\"https://localhost:44311/Order\" class=\"button\">Siparişi onalamak için lütfen bağlantıya tıklayınız.</a>";
              
                string subject = "Sipariş";
                MailMessage msg = new MailMessage("firmalogoinf@gmail.com", model.Email, subject, text);
                msg.IsBodyHtml = true;
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.UseDefaultCredentials = false;
                NetworkCredential cre = new NetworkCredential("firmalogoinf@gmail.com", "555K1818p..pp");
                sc.Credentials = cre;
                sc.EnableSsl = true;
                sc.Send(msg);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}

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
        Context c = new Context();
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
        public IActionResult OrderApprove(int id)
        {
            var order = c.Orders.Find(id);
            order.Status = true;
            c.Orders.Update(order);
            c.SaveChanges();

            return RedirectToAction("OrderApproved");
        }
        public IActionResult OrderApproved()
        {
            return View();
        }
        public IActionResult ForwardMail()
        {
            return View();
        }


        public IActionResult SendMail(OrderMail model)
        {
            if (model != null)
            {
                var order = new Order();
                order.UserID = 1;
                order.Address = model.Address;
                order.CardName = model.CardName;
                order.CardNumber = model.CardNumber;
                order.City = model.City;
                order.CVV = model.CVV;
                order.Email = model.Email;
                order.ExpJahr = model.ExpJahr;
                order.ExpMonat = model.ExpMonat;
                order.FirstName = model.FirstName;
                order.SameAddr = model.SameAddr;
                order.ZipCode = model.ZipCode;
                order.State = model.State;
                order.Status = false;

                c.Orders.Add(order);
                c.SaveChanges();
                int orderId = order.OrderID;
                string text = "<h1>Bestellinformationen</h1>" + "<label>Kunde : </label><label>" + model.FirstName + "</label>" + "<br>" + "<label>Adresse : </label><label>" + model.Address + "</label>" + "<br>" + "<label>Kreditkartennummer : </label><label>" + model.CardNumber + "</label>"
                    + "<br>";
                text += "<br><table><thead><th>   Produktname   </th><th>   Produktmenge   </th><th>   Preis   </th></thead><tbody>";
                var cart = SessionManager.GetCart(HttpContext.Session);
                ProductRepository productRepository = new ProductRepository();
                foreach (var item in cart)
                {
                   
                    text += "<tr>";
                    Product product = productRepository.TFind(item.Item1);
                    var orderProduct = new OrderProduct();
                    orderProduct.OrderID = orderId;
                    orderProduct.ProductName = product.ProductName;
                    orderProduct.Price = product.Price;
                    orderProduct.Stock = item.Item2;
                    c.OrderProducts.Add(orderProduct);
                    c.SaveChanges();
                    text += "<td>" + product.ProductName + "</td>";
                    text += "<td>" + item.Item2 + "</td>";
                    text += "<td>" + product.Price * item.Item2 + "</td>";
                    text += "</tr>";
                    var stock = c.Products.Find(product.ProductID);
                    stock.Stock -= item.Item2;
                    c.Products.Update(stock);
                    c.SaveChanges(); 
                }
                text += "</tbody></table><br>";
                text+= "Bestätigen Sie die Bestellung?" + "<br>"+ "<a href=\"https://localhost:44311/Order/OrderApprove/" + orderId + "\" class=\"button\">Bitte klicken Sie auf den Link, um Ihre Bestellung zu bestätigen.</a>";
              
                string subject = "Bestellung";
                MailMessage msg = new MailMessage("firmalogoinf@gmail.com", model.Email, subject, text);
                msg.IsBodyHtml = true;
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.UseDefaultCredentials = false;
                NetworkCredential cre = new NetworkCredential("firmalogoinf@gmail.com", "555K1818p..pp");
                sc.Credentials = cre;
                sc.EnableSsl = true;
                sc.Send(msg);
                return RedirectToAction("ForwardMail");
            }

            return RedirectToAction("Index");
        }
    }
}

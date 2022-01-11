using EBusiness.Data;
using EBusiness.Data.Models;
using EBusiness.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBusiness.ViewComponents
{
    public class CardContents : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ProductRepository productRepository = new ProductRepository();
            List<Tuple<Product, int>> cartContents = new List<Tuple<Product, int>>();
            List<Tuple<int, int>> cartList = SessionManager.GetCart(HttpContext.Session);

            // Turn id, amount tuple to product, amount tuple
            foreach (Tuple<int, int> item in cartList)
            {
                Product product = productRepository.TFind(item.Item1);
                cartContents.Add(new Tuple<Product, int>(product, item.Item2));
            }

            return View(cartContents);
        }
    }
}

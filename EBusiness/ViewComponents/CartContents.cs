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
    public class CartContents : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ProductRepository productRepository = new ProductRepository();
            List<Tuple<Product, int>> cartContents = new List<Tuple<Product, int>>();
            List<Tuple<int, int>> cartList = SessionManager.GetCart(HttpContext.Session);

            //Debug mock data
            //List<Tuple<int, int>> cartList = new List<Tuple<int, int>>();
            //cartList.Add(new Tuple<int, int>(3, 1));
            //cartList.Add(new Tuple<int, int>(5, 2));

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

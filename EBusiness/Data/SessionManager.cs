using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBusiness.Data
{
    public static class SessionManager
    {
        private static void StoreObjectInSession<T>(ISession session, string key, T obj)
        {
            string jsonString = JsonSerializer.Serialize(obj);
            session.SetString(key, jsonString);
        }
        public static Cart GetCart(ISession session)
        {
            string cartString = session.GetString("cart");
            if(cartString == null)
            {
                Cart cart = new Cart();
                StoreObjectInSession(session, "cart", cart);
                return cart;
            }

            return JsonSerializer.Deserialize<Cart>(cartString);
        }

        public static void SetCart(ISession session, Cart cart)
        {
            StoreObjectInSession(session, "cart", cart);
        }
    }
}
